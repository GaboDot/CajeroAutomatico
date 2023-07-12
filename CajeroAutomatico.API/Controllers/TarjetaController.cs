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
    public class TarjetaController : ControllerBase
    {
        private readonly ITarjetaService _tarjetaService;

        public TarjetaController(ITarjetaService tarjetaService)
        {
            _tarjetaService = tarjetaService;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista(int idCuenta)
        {
            var response = new Response<List<TarjetaClienteDTO>>();
            try
            {
                response.status = true;
                response.value = await _tarjetaService.Lista(idCuenta);
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
        public async Task<IActionResult> Guardar([FromBody] TarjetaClienteDTO tarjeta)
        {
            var response = new Response<TarjetaClienteDTO>();
            try
            {
                response.status = true;
                response.value = await _tarjetaService.Crear(tarjeta);
            }
            catch (Exception exc)
            {
                response.status = false;
                response.message = exc.Message;
            }

            return Ok(response);
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] TarjetaClienteDTO tarjeta)
        {
            var response = new Response<bool>();
            try
            {
                response.status = true;
                response.value = await _tarjetaService.Editar(tarjeta);
            }
            catch (Exception exc)
            {
                response.status = false;
                response.message = exc.Message;
            }

            return Ok(response);
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var response = new Response<bool>();
            try
            {
                response.status = true;
                response.value = await _tarjetaService.Eliminar(id);
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
