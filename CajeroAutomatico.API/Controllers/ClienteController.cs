using CajeroAutomatico.BLL.Servicios.Contrato;
using CajeroAutomatico.DTO;
using Microsoft.AspNetCore.Mvc;
using CajeroAutomatico.API.Utils;

namespace CajeroAutomatico.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var response = new Response<List<ClienteDTO>>();
            try
            {
                response.status = true;
                response.value = await _clienteService.Lista();
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
        public async Task<IActionResult> Guardar([FromBody] ClienteDTO cliente)
        {
            var response = new Response<ClienteDTO>();
            try
            {
                response.status = true;
                response.value = await _clienteService.Crear(cliente);
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
        public async Task<IActionResult> Editar([FromBody] ClienteDTO cliente)
        {
            var response = new Response<bool>();
            try
            {
                response.status = true;
                response.value = await _clienteService.Editar(cliente);
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
                response.value = await _clienteService.Eliminar(id);
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
