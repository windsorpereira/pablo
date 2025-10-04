using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel
{
    public class Cliente
    {
        public Cliente()
        {
            Portes = new List<Porte>();
            Ativo = true;
        }

        public Cliente(Data.Model.Cliente cliente)
        {
            Id = cliente.Id;
            Ativo = cliente.Ativo;
            Cnpj = cliente.Cnpj.HasValue ? cliente.Cnpj.Value.ToString(@"00\.000\.000\/0000\-00") : null;
            NomeFantasia = cliente.NomeFantasia;
            Porte = cliente.Porte != null ? new Porte() { Id = cliente.Porte.Id, Nome = cliente.Porte.Nome } : new Porte();
            PorteId = cliente.PorteId;
            RazaoSocial = cliente.RazaoSocial;

            Portes = new List<Porte>();
        }

        public virtual int Id { get; set; }

        [Required(ErrorMessage = "Nome Fantasia é obrigatório", AllowEmptyStrings = false)]
        public virtual string NomeFantasia { get; set; }

        [Required(ErrorMessage = "Porte é obrigatório", AllowEmptyStrings = false)]
        [Range(1, int.MaxValue, ErrorMessage = "Porte é obrigatório")]
        public virtual int PorteId { get; set; }

        [StringLength(14, MinimumLength = 14, ErrorMessage = "CNPJ inválido")]
        public virtual string Cnpj { get; set; }

        public virtual string RazaoSocial { get; set; }

        public virtual bool Ativo{ get; set; }

        public virtual Porte Porte { get; set; }

        public virtual IList<Porte> Portes { get; set; }
    }
}
