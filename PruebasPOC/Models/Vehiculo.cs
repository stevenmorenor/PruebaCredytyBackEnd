using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebasPOC.Models
{
    public class Vehiculo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? TipoVehiculo { get; set; }
        public string? Placa { get; set; }
        public DateTime HoraIngreso { get; set; }
        public string? FacturaSupermercado { get; set; }
    }
}
