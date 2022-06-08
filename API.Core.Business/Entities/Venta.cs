using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Core.Business.Entities
{
    public class Venta
    {
        [Key]
        public int idVenta { get; set; }

        [Required]
        public double importe { get; set; }

        public double descuento { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime fecha { get; set; }

        [ForeignKey("Vehiculo")]
        public int idVehiculo { get; set; }

        public Vehiculo? vehiculo { get; set; }

        [ForeignKey("Cliente")]
        public int idCliente { get; set; }

        public Cliente? cliente { get; set; }
    }
}
