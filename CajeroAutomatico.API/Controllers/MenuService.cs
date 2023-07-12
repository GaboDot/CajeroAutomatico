using CajeroAutomatico.BLL.Servicios.Contrato;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CajeroAutomatico.API.Utils;
using CajeroAutomatico.BLL.Servicios;
using CajeroAutomatico.DTO;

namespace CajeroAutomatico.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuService : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuService(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista(int idCliente)
        {
            var response = new Response<List<MenuDTO>>();
            try
            {
                response.status = true;
                response.value = await _menuService.Lista(idCliente);
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
