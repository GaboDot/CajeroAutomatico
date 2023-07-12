using CajeroAutomatico.DTO;

namespace CajeroAutomatico.BLL.Servicios.Contrato
{
    public interface ICuentaService
    {
        Task<List<CuentaDTO>> Lista();

        Task<CuentaDTO> Crear(CuentaDTO model);

        Task<bool> Editar(CuentaDTO model);

        Task<bool> Eliminar(int id);
    }
}
