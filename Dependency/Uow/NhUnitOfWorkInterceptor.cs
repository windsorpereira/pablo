﻿using System.Reflection;
using Castle.DynamicProxy;
using Data.NHibernate;
using NHibernate;
using IInterceptor = Castle.DynamicProxy.IInterceptor;
using System;
namespace Dependency.Uow
{
    /// <summary>
    /// This interceptor is used to manage transactions.
    /// </summary>
    public class NhUnitOfWorkInterceptor : IInterceptor
    {
        private readonly ISessionFactory _sessionFactory;

        /// <summary>
        /// Creates a new NhUnitOfWorkInterceptor object.
        /// </summary>
        /// <param name="sessionFactory">Nhibernate session factory.</param>
        public NhUnitOfWorkInterceptor(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        /// <summary>
        /// Intercepts a method.
        /// </summary>
        /// <param name="invocation">Method invocation arguments</param>
        public void Intercept(IInvocation invocation)
        {
            //If there is a running transaction, just run the method
            if (NhUnitOfWork.Current != null || !RequiresDbConnection(invocation.MethodInvocationTarget))
            {
                invocation.Proceed();
                return;
            }

            try
            {
                NhUnitOfWork.Current = new NhUnitOfWork(_sessionFactory);
                NhUnitOfWork.Current.BeginTransaction();

                try
                {
                    invocation.Proceed();
                    NhUnitOfWork.Current.Commit();
                }
                catch (Exception ex)
                {
                    try
                    {
                        NhUnitOfWork.Current.Rollback();
                    }
                    catch
                    {

                    }

                    throw;
                }
            }
            finally
            {
                NhUnitOfWork.Current = null;
            }
        }

        private static bool RequiresDbConnection(MethodInfo methodInfo)
        {
            if (UnitOfWorkHelper.HasUnitOfWorkAttribute(methodInfo))
            {
                return true;
            }

            if (UnitOfWorkHelper.IsRepositoryMethod(methodInfo))
            {
                return true;
            }

            return false;
        }
    }
}
