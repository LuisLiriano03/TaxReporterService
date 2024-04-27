using AutoMapper;
using Microsoft.Extensions.Options;
using TaxReporter.DTOs.Menu;
using TaxReporter.DTOs.Rol;
using TaxReporter.DTOs.User;
using TaxReporter.Entities;

namespace TaxReporter.AutoMapper
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {

            CreateMap<Rol, GetRol>().ReverseMap();
            CreateMap<Menu, GetMenu>().ReverseMap();

            CreateMap<UserInfo, GetUser>()
                .ForMember(destination =>
                    destination.RolDescription,
                    options => options.MapFrom(origin => origin.Rol.NameRol)
                 )
                .ForMember(destination =>
                    destination.IsActive,
                    options => options.MapFrom(origin => origin.IsActive == true ? 1 : 0)
                );

            CreateMap<GetUser, UserInfo>()
                .ForMember(destination =>
                    destination.Rol,
                    options => options.Ignore()
                 )
                .ForMember(destination =>
                    destination.IsActive,
                    options => options.MapFrom(origin => origin.IsActive == 1 ? true : false)
                );


            CreateMap<UserInfo, LoginResponse>()
                .ForMember(destino =>
                    destino.RolDescription,
                    options => options.MapFrom(origen => origen.Rol.NameRol)
                );

            CreateMap<UserInfo, LoginRequest>().ReverseMap();


        }

    }
}
