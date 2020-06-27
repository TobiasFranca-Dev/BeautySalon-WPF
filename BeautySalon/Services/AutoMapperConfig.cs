using AutoMapper;
using BeautySalon.Models;
using BeautySalon.ViewModels;

namespace BeautySalon.Services
{
    public static class AutoMapperConfig
    {
        public static Mapper Mapear()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Cliente, ClienteEditeViewModel>().ReverseMap();
                cfg.CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            });

            return new Mapper(config);
        }
    }
}
