using CajeroAutomatico.DTO;

namespace CajeroAutomatico.BLL.Servicios.Contrato
{
    public interface ITarjetaService
    {
        Task<List<TarjetaClienteDTO>> Lista(int idCuenta);

        Task<TarjetaClienteDTO> Crear(TarjetaClienteDTO model);

        Task<bool> Editar(TarjetaClienteDTO model);

        Task<bool> Eliminar(int id);
    }
}
