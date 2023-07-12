using CajeroAutomatico.DTO;

namespace CajeroAutomatico.BLL.Servicios.Contrato
{
    public interface IClienteService
    {
        Task<List<ClienteDTO>> Lista();

        Task<ClienteDTO> Crear(ClienteDTO model);

        Task<bool> Editar(ClienteDTO model);

        Task<bool> Eliminar(int id);
    }
}
