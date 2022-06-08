using API.Core.Business.filtros;
using System.ComponentModel.DataAnnotations;

namespace API.Core.Business.Entities
{
    public class Vehiculo
    {
        [Key]
        public int idVehculo { get; set; }

        [Required]
        public string? marca { get; set; }

        [Required]
        public string? modelo { get; set; }

        [Required]
        [TeslaCar(2009)]
        public int fechaModelo { get; set; }

        [Required]
        public float precio { get; set; }

        [DataType(DataType.Date)]
        public DateTime fechaBaja { get; set; }


    }
}
