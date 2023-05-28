using AutoMapper;
using TaskManagement.Services.DTOs;
using TaskManagement.Services.Models;

namespace TaskManagement.Services
{
    public class MappingConfig 
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProjectDTO, Project>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
