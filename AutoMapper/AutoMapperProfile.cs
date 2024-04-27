using AutoMapper;
using TaxReporter.DTOs.Menu;
using TaxReporter.DTOs.Rol;
using TaxReporter.Entities;

namespace TaxReporter.AutoMapper
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile() 
        { 
           
            CreateMap<Rol,GetRol>().ReverseMap();
            CreateMap<Menu, GetMenu>().ReverseMap();




        
        }

    }
}
