using System.ComponentModel.DataAnnotations;

namespace PruebasPOC.Models
{
    public class Tarifa
    {
        [Key]
        public string? TipoVehiculo { get; set; }
        public decimal MontoTarifa { get; set; }
    }
}
