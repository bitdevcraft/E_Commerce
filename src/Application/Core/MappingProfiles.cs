using Application.Models;
using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Model, Model>();
            CreateMap<Model, ModelDto>();
            CreateMap<AppCompany, AppCompany>();


        }
    }
}
