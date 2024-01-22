using System.ComponentModel.DataAnnotations;

namespace PruebasPOC.Models
{
    public class Ingreso
    {
        [Key]
        public int Id { get; set; }
        public int VehiculoId { get; set; }
        public DateTime HoraSalida { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
