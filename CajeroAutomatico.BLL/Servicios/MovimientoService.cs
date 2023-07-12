using AutoMapper;
using CajeroAutomatico.BLL.Servicios.Contrato;
using CajeroAutomatico.DAL.Repositories.Contrato;
using CajeroAutomatico.DTO;
using CajeroAutomatico.Model;
using Microsoft.EntityFrameworkCore;

namespace CajeroAutomatico.BLL.Servicios
{
    public class MovimientoService : IMovimientoService
    {
        private readonly IGenericRepository<Movimiento> _movimientoRepository;
        private readonly IMapper _mapper;

        public MovimientoService(IGenericRepository<Movimiento> movimientoRepository, IMapper mapper)
        {
            _movimientoRepository = movimientoRepository;
            _mapper = mapper;
        }
        public async Task<List<MovimientoDTO>> Lista(int idCuenta)
        {
            try
            {
                var queryMovimiento = await _movimientoRepository.Consultar(m => m.IdCuenta == idCuenta);
                var listaMovimientos = queryMovimiento.Include(m => m.IdCuentaNavigation).ToList();
                return _mapper.Map<List<MovimientoDTO>>(listaMovimientos);
            }
            catch (Exception)
            { throw; }
        }

        public async Task<MovimientoDTO> Crear(MovimientoDTO model)
        {
            try
            {
                var movimientoRegistrado = await _movimientoRepository.Crear(_mapper.Map<Movimiento>(model));
                if (movimientoRegistrado.IdMovimiento == 0)
                    throw new TaskCanceledException("No se pudo registrar el movimiento");

                var query = await _movimientoRepository.Consultar(m => m.IdMovimiento == movimientoRegistrado.IdMovimiento);
                movimientoRegistrado = query.Include(m => m.IdCuentaNavigation).First();
                return _mapper.Map<MovimientoDTO>(movimientoRegistrado);
            }
            catch (Exception)
            { throw; }
        }

    }
}
