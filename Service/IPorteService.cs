﻿using Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IPorteService
    {
        IList<Porte> ObterTodos();
    }
}
