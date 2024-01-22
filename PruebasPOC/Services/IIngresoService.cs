using PruebasPOC.Models;

namespace PruebasPOC.Services
{
    public interface IIngresoService
    {
        Ingreso LiquidarIngreso(int vehiculoId, string facturaSupermercado);
    }
}
