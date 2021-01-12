using AutoMapper;
using SpaceApp.Entity;
using SpaceApp.Models;

namespace SpaceApp.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterModel, User>();
        }
    }
}
