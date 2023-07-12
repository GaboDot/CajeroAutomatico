using AutoMapper;
using CajeroAutomatico.BLL.Servicios.Contrato;
using CajeroAutomatico.DAL.Repositories.Contrato;
using CajeroAutomatico.DTO;
using CajeroAutomatico.Model;
using Microsoft.EntityFrameworkCore;

namespace CajeroAutomatico.BLL.Servicios
{
    public class TarjetaService: ITarjetaService
    {
        private readonly IGenericRepository<TarjetaCliente> _tarjetaRepositorio;
        private readonly IMapper _mapper;

        public TarjetaService(IGenericRepository<TarjetaCliente> tarjetaRepositorio, IMapper mapper)
        {
            _tarjetaRepositorio = tarjetaRepositorio;
            _mapper = mapper;
        }
        public async Task<List<TarjetaClienteDTO>> Lista(int idCuenta)
        {
            try
            {
                var listaClientes = (await _tarjetaRepositorio.Consultar()).ToList();
                return _mapper.Map<List<TarjetaClienteDTO>>(listaClientes);
            }
            catch (Exception)
            { throw; }
        }

        public async Task<TarjetaClienteDTO> Crear(TarjetaClienteDTO model)
        {
            try
            {
                var tarjetaCreada = await _tarjetaRepositorio.Crear(_mapper.Map<TarjetaCliente>(model));
                if (tarjetaCreada.IdTarjeta == 0)
                    throw new TaskCanceledException("No se pudo generar la tarjeta");

                var query = await _tarjetaRepositorio.Consultar(t => t.IdTarjeta == tarjetaCreada.IdTarjeta);
                tarjetaCreada = query.Include(t => t.IdCuenta).First();
                return _mapper.Map<TarjetaClienteDTO>(tarjetaCreada);
            }
            catch (Exception)
            { throw; }
        }

        public async Task<bool> Editar(TarjetaClienteDTO model)
        {
            try
            {
                var tarjetaModelo = _mapper.Map<TarjetaCliente>(model);
                var tarjetaEncontrada = await _tarjetaRepositorio.Obtener(t => t.IdTarjeta == model.IdTarjeta);
                if (tarjetaEncontrada == null)
                    throw new TaskCanceledException("No existe la tarjeta");

                tarjetaEncontrada.NumeroTarjeta = model.NumeroTarjeta;
                tarjetaEncontrada.FechaExpedicion = model.FechaExpedicion;
                tarjetaEncontrada.FechaExpiracion = model.FechaExpiracion;

                bool respuesta = await _tarjetaRepositorio.Editar(tarjetaEncontrada);
                if (!respuesta)
                    throw new TaskCanceledException("Error al actualizar la tarjeta");

                return respuesta;
            }
            catch (Exception)
            { throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var tarjetaEncontrada = await _tarjetaRepositorio.Obtener(t => t.IdTarjeta == id);
                if (tarjetaEncontrada == null)
                    throw new TaskCanceledException("No existe la tarjeta");

                bool respuesta = await _tarjetaRepositorio.Eliminar(tarjetaEncontrada);
                if (!respuesta)
                    throw new TaskCanceledException("Error al eliminar la tarjeta");

                return respuesta;
            }
            catch (Exception)
            { throw; }
        }

    }
}
