using AutoMapper;
using Entities.DTOs.Board;
using Entities.DTOs.TaskChecklist;
using Entities.Models;

namespace TasklyAPI.TasklyMapper
{
    public class TasklyMappings : Profile
    {
        public TasklyMappings()
        {
            CreateMap<Entities.Models.Task, Entities.DTOs.Task.TaskDto>().ForMember(d => d.TaskChecklists, conf => conf.MapFrom(s => s.TaskChecklists)).ReverseMap();
            CreateMap<TaskChecklist, TaskChecklistDto>().ReverseMap();
            CreateMap<Board, BoardDto>().ReverseMap();
        }
    }
}
