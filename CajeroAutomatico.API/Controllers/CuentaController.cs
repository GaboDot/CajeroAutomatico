using CajeroAutomatico.BLL.Servicios;
using CajeroAutomatico.BLL.Servicios.Contrato;
using CajeroAutomatico.DTO;
using CajeroAutomatico.API.Utils;
using Microsoft.AspNetCore.Mvc;

namespace CajeroAutomatico.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        private readonly ICuentaService _cuentaService;

        public CuentaController(ICuentaService cuentaService)
        {
            _cuentaService = cuentaService;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var response = new Response<List<CuentaDTO>>();
            try
            {
                response.status = true;
                response.value = await _cuentaService.Lista();
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
        public async Task<IActionResult> Guardar([FromBody] CuentaDTO cuenta)
        {
            var response = new Response<CuentaDTO>();
            try
            {
                response.status = true;
                response.value = await _cuentaService.Crear(cuenta);
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
        public async Task<IActionResult> Editar([FromBody] CuentaDTO cuenta)
        {
            var response = new Response<bool>();
            try
            {
                response.status = true;
                response.value = await _cuentaService.Editar(cuenta);
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
                response.value = await _cuentaService.Eliminar(id);
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
