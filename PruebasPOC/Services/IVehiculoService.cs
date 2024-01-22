using PruebasPOC.Models;

namespace PruebasPOC.Services
{
    public interface IVehiculoService
    {
        Vehiculo RegistrarIngreso(Vehiculo vehiculo);
        List<Vehiculo> ObtenerVehiculosEnRangoDeTiempo(DateTime inicio, DateTime fin);
        Vehiculo ObtenerVehiculoPorId(int id);
        decimal LiquidarValorSalida(Vehiculo vehiculo, bool clienteRealizoCompra, decimal totalCompra);
    }
}
