using CajeroAutomatico.DTO;

namespace CajeroAutomatico.BLL.Servicios.Contrato
{
    public interface IMovimientoService
    {
        Task<List<MovimientoDTO>> Lista(int idCuenta);

        Task<MovimientoDTO> Crear(MovimientoDTO model);
    }
}
