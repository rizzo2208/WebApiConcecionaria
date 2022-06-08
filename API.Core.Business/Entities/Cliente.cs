using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Core.Business.Entities
{
    public class Cliente
    {
        [Key]
        public int idCliente { get; set; }

        [Required]
        public string? Nombre { get; set; }

        [Required]
        public string? Apelido { get; set; }

        [Required]
        public string? dni { get; set; }

        [Required]
        public string? dieccion { get; set; }



    }
}
