using CajeroAutomatico.BLL.Servicios;
using CajeroAutomatico.BLL.Servicios.Contrato;
using CajeroAutomatico.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CajeroAutomatico.API.Utils;

namespace CajeroAutomatico.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoController : ControllerBase
    {
        private readonly IMovimientoService _movimientoService;

        public MovimientoController(IMovimientoService movimientoService)
        {
            _movimientoService = movimientoService;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista(int idCuenta)
        {
            var response = new Response<List<MovimientoDTO>>();
            try
            {
                response.status = true;
                response.value = await _movimientoService.Lista(idCuenta);
            }
            catch (Exception exc)
            {
                response.status = false;
                response.message = exc.Message;
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] MovimientoDTO movimiento)
        {
            var response = new Response<MovimientoDTO>();
            try
            {
                response.status = true;
                response.value = await _movimientoService.Crear(movimiento);
            }
            catch (Exception exc)
            {
                response.status = false;
                response.message = exc.Message;
            }

            return Ok(response);
        }
    }
}
