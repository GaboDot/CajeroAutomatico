using AutoMapper;
using CajeroAutomatico.BLL.Servicios.Contrato;
using CajeroAutomatico.DAL.Repositories.Contrato;
using CajeroAutomatico.DTO;
using CajeroAutomatico.Model;
using Microsoft.EntityFrameworkCore;

namespace CajeroAutomatico.BLL.Servicios
{
    public class CuentaService: ICuentaService
    {
        private readonly IGenericRepository<Cuenta> _cuentaRepositorio;
        private readonly IMapper _mapper;

        public CuentaService(IGenericRepository<Cuenta> cuentaRepositorio, IMapper mapper)
        {
            _cuentaRepositorio = cuentaRepositorio;
            _mapper = mapper;
        }
        public async Task<List<CuentaDTO>> Lista()
        {
            try
            {
                var queryCuenta = await _cuentaRepositorio.Consultar();
                var listacuentas = queryCuenta
                    .Include(cuenta => cuenta.IdClienteNavigation)
                    .ToList();
                return _mapper.Map<List<CuentaDTO>>(listacuentas);
            }
            catch (Exception)
            { throw; }
        }

        public async Task<CuentaDTO> Crear(CuentaDTO model)
        {
            try
            {
                var cuentaCreada = await _cuentaRepositorio.Crear(_mapper.Map<Cuenta>(model));
                if (cuentaCreada.IdCuenta == 0)
                    throw new TaskCanceledException("No se pudo crear la cuenta");

                var query = await _cuentaRepositorio.Consultar(u => u.IdCuenta == cuentaCreada.IdCuenta);
                cuentaCreada = query
                    .Include(cuenta => cuenta.IdClienteNavigation)
                    .Include(cuenta => cuenta.IdTarjetaNavigation)
                    .First();
                return _mapper.Map<CuentaDTO>(cuentaCreada);
            }
            catch (Exception)
            { throw; }
        }

        public async Task<bool> Editar(CuentaDTO model)
        {
            try
            {
                var cuentaModelo = _mapper.Map<CuentaDTO>(model);
                var cuentaEncontrada = await _cuentaRepositorio.Obtener(u => u.IdCuenta == cuentaModelo.IdCuenta);
                if (cuentaEncontrada == null)
                    throw new TaskCanceledException("No existe la cuenta");

                cuentaEncontrada.Saldo = model.Saldo;

                bool respuesta = await _cuentaRepositorio.Editar(cuentaEncontrada);
                if (!respuesta)
                    throw new TaskCanceledException("Error al actualizar la cuenta");

                return respuesta;
            }
            catch (Exception)
            { throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var cuentaEncontrada = await _cuentaRepositorio.Obtener(u => u.IdCuenta == id);
                if (cuentaEncontrada == null)
                    throw new TaskCanceledException("No existe la cuenta");

                bool respuesta = await _cuentaRepositorio.Eliminar(cuentaEncontrada);
                if (!respuesta)
                    throw new TaskCanceledException("Error al eliminar la cuenta");

                return respuesta;
            }
            catch (Exception)
            { throw; }
        }

    }
}
