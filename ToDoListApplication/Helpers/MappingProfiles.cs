using AutoMapper;
using ToDoListApplication.DataAccess.Models;
using ToDoListApplication.DTO;

namespace ToDoListApplication.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<ToDoItem, ToDoItemDTO>();
        }
    }
}
