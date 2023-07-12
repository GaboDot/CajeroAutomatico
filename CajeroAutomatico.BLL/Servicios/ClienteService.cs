using AutoMapper;
using CajeroAutomatico.BLL.Servicios.Contrato;
using CajeroAutomatico.DAL.Repositories.Contrato;
using CajeroAutomatico.DTO;
using CajeroAutomatico.Model;
using Microsoft.EntityFrameworkCore;

namespace CajeroAutomatico.BLL.Servicios
{
    public class ClienteService : IClienteService
    {
        private readonly IGenericRepository<Cliente> _clienteRepositorio;
        private readonly IMapper _mapper;

        public ClienteService(IGenericRepository<Cliente> clienteRepositorio, IMapper mapper)
        {
            _clienteRepositorio = clienteRepositorio;
            _mapper = mapper;
        }

        public async Task<List<ClienteDTO>> Lista()
        {
            try
            {
                var queryCliente = await _clienteRepositorio.Consultar();
                var listaClientes = queryCliente.Include(rol => rol.IdRolNavigation).ToList();
                return _mapper.Map<List<ClienteDTO>>(listaClientes);
            }
            catch (Exception)
            { throw; }
        }

        public async Task<ClienteDTO> Crear(ClienteDTO model)
        {
            try
            {
                var clienteCreado = await _clienteRepositorio.Crear(_mapper.Map<Cliente>(model));
                if (clienteCreado.IdCliente == 0)
                    throw new TaskCanceledException("No se pudo crear el cliente");

                var query = await _clienteRepositorio.Consultar(u => u.IdCliente == clienteCreado.IdCliente);
                clienteCreado = query.Include(rol => rol.IdRolNavigation).First();
                return _mapper.Map<ClienteDTO>(clienteCreado);
            }
            catch (Exception)
            { throw; }
        }

        public async Task<bool> Editar(ClienteDTO model)
        {
            try
            {
                var clienteModelo = _mapper.Map<Cliente>(model);
                var clienteEncontrado = await _clienteRepositorio.Obtener(u => u.IdCliente == clienteModelo.IdCliente);
                if (clienteEncontrado == null)
                    throw new TaskCanceledException("No existe el cliente");

                clienteEncontrado.Nombre = clienteModelo.Nombre;
                clienteEncontrado.ApellidoPaterno = clienteModelo.ApellidoPaterno;
                clienteEncontrado.ApellidoMaterno = clienteModelo.ApellidoMaterno;

                bool respuesta = await _clienteRepositorio.Editar(clienteEncontrado);
                if (!respuesta)
                    throw new TaskCanceledException("Error al editar el cliente");

                return respuesta;
            }
            catch (Exception)
            { throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var clienteEncontrado = await _clienteRepositorio.Obtener(u => u.IdCliente == id);
                if (clienteEncontrado == null)
                    throw new TaskCanceledException("No existe el cliente");

                bool respuesta = await _clienteRepositorio.Eliminar(clienteEncontrado);
                if (!respuesta)
                    throw new TaskCanceledException("Error al eliminar el cliente");

                return respuesta;
            }
            catch (Exception)
            { throw; }
        }
    }
}
