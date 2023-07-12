using CajeroAutomatico.DTO;

namespace CajeroAutomatico.BLL.Servicios.Contrato
{
    public interface IMenuService
    {
        Task<List<MenuDTO>> Lista(int idCliente);
    }
}
