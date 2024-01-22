using PruebasPOC.Infraestructure;
using PruebasPOC.Models;

namespace PruebasPOC.Services
{
    public class VehiculoService : IVehiculoService
    {
        private readonly ApplicationDbContext _context;

        public VehiculoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Vehiculo RegistrarIngreso(Vehiculo vehiculo)
        {
            vehiculo.HoraIngreso = DateTime.Now;
            _context.Vehiculos.Add(vehiculo);
            _context.SaveChanges();
            return vehiculo;
        }

        public List<Vehiculo> ObtenerVehiculosEnRangoDeTiempo(DateTime inicio, DateTime fin)
        {
            return _context.Vehiculos
                .Where(v => v.HoraIngreso >= inicio && v.HoraIngreso <= fin)
                .ToList();
        }

        public Vehiculo ObtenerVehiculoPorId(int id)
        {
            var vehiculo = _context.Vehiculos.Find(id);

            // Verificar si vehiculo es nulo antes de devolverlo
            if (vehiculo != null)
            {
                return vehiculo;
            }
            throw new InvalidOperationException($"No se encontró un vehículo con el ID {id}");
        }


        public decimal LiquidarValorSalida(Vehiculo vehiculo, bool clienteRealizoCompra, decimal totalCompra)
        {
            // Verificar si vehiculo y TipoVehiculo no son nulos antes de continuar
            if (vehiculo != null && vehiculo.TipoVehiculo != null)
            {
                // Lógica para calcular el valor a pagar según el tipo de vehículo
                decimal tarifa = ObtenerTarifaSegunTipo(vehiculo.TipoVehiculo);

                // Aplicar descuento si el cliente realizó una compra
                if (clienteRealizoCompra)
                {
                    // Aplicar un descuento del 30%
                    decimal descuento = 0.3m;
                    tarifa = -tarifa * descuento;
                }

                return tarifa;
            }
            throw new InvalidOperationException("El vehículo o el tipo de vehículo es nulo.");
        }


        private decimal ObtenerTarifaSegunTipo(string tipoVehiculo)
        {

            return tipoVehiculo switch
            {
                "Carro" => 110m,
                "Motocicleta" => 50m,
                "Bicicleta" => 10m,
                _ => 0m, // Valor predeterminado si no se encuentra el tipo de vehículo
            };
        }
    }
}
