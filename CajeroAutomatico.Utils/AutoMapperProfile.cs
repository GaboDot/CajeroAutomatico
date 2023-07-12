
using AutoMapper;
using CajeroAutomatico.DTO;
using CajeroAutomatico.Model;

namespace CajeroAutomatico.Utils
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile() 
        { 
            CreateMap<Cliente, ClienteDTO>().ReverseMap();

            CreateMap<Cuenta, CuentaDTO>().ReverseMap();

            CreateMap<Menu, MenuDTO>().ReverseMap();

            CreateMap<Movimiento, MovimientoDTO>().ReverseMap();

            CreateMap<TarjetaCliente, TarjetaClienteDTO>().ReverseMap();

            CreateMap<Cliente, SesionDTO>().ReverseMap();
            CreateMap<Cuenta, SesionDTO>().ReverseMap();
        }
    }
}
