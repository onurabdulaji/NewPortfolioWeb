using AutoMapper;
using DTO.Map.Mapper.Register;
using EL.Models;

namespace UI.Map.Mapper
{
    public class Map : Profile
    {
        public Map()
        {
            CreateMap<RegisterUserVM, AppUser>();
        }
    }
}
