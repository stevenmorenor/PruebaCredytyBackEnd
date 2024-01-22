using Microsoft.AspNetCore.Mvc;
using PruebasPOC.Models;
using PruebasPOC.Services;

[ApiController]
[Route("api/[controller]")]
public class VehiculoController : ControllerBase
{
    private readonly IVehiculoService _vehiculoService;

    public VehiculoController(IVehiculoService vehiculoService)
    {
        _vehiculoService = vehiculoService;
    }

    [HttpPost("registrar-ingreso")]
    public IActionResult RegistrarIngreso([FromBody] Vehiculo vehiculo)
    {
        try
        {
            var vehiculoIngresado = _vehiculoService.RegistrarIngreso(vehiculo);
            return Ok(vehiculoIngresado);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "Error al registrar el ingreso del vehículo.");
        }
    }

    [HttpGet("liquidar-valor-salida/{id}")]
    public IActionResult LiquidarValorSalida(int id, [FromQuery] bool clienteRealizoCompra, [FromQuery] decimal totalCompra)
    {
        try
        {
            var vehiculo = _vehiculoService.ObtenerVehiculoPorId(id);
            var valorAPagar = _vehiculoService.LiquidarValorSalida(vehiculo, clienteRealizoCompra, totalCompra);
            return Ok(valorAPagar);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "Error al liquidar el valor de salida del vehículo.");
        }
    }

    [HttpGet("obtener-vehiculos-en-rango")]
    public IActionResult ObtenerVehiculosEnRango([FromQuery] DateTime inicio, [FromQuery] DateTime fin)
    {
        try
        {
            var vehiculos = _vehiculoService.ObtenerVehiculosEnRangoDeTiempo(inicio, fin);
            return Ok(vehiculos);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "Error al obtener vehículos en el rango de tiempo especificado.");
        }
    }

}
