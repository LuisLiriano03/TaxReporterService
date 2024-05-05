using AutoMapper;
using Microsoft.Extensions.Options;
using TaxReporter.DTOs.InvoiceState;
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
            CreateMap<InvoiceState, GetState>().ReverseMap();
            CreateMap<Menu, GetMenu>().ReverseMap();

            CreateMap<UserInfo, CreateUser>()
                .ForMember(destination =>
                    destination.IsActive,
                    options => options.MapFrom(origin => origin.IsActive == true ? 1 : 0)
                );

            CreateMap<CreateUser, UserInfo>()
                .ForMember(destination =>
                    destination.IsActive,
                    options => options.MapFrom(origin => origin.IsActive == 1 ? true : false)
                );

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

            CreateMap<UserInfo, UpdateUser>()
                .ForMember(destination =>
                    destination.IsActive,
                    options => options.MapFrom(origin => origin.IsActive == true ? 1 : 0)
                );

            CreateMap<UpdateUser, UserInfo>()
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
