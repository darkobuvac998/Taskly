using AutoMapper;
using Entities.DTOs.Board;
using Entities.DTOs.Priority;
using Entities.DTOs.Status;
using Entities.DTOs.Task;
using Entities.DTOs.TaskChecklist;
using Entities.Models;

namespace TasklyAPI.TasklyMapper
{
    public class TasklyMappings : Profile
    {
        public TasklyMappings()
        {
            //Task Mapping
            CreateMap<Entities.Models.Task, Entities.DTOs.Task.TaskDto>().ForMember(d => d.TaskChecklists, conf => conf.MapFrom(s => s.TaskChecklists)).ReverseMap();
            CreateMap<TaskCreationDto, Entities.Models.Task>();
            CreateMap<TaskUpdateDto, Entities.Models.Task>();

            // Board Mapping
            CreateMap<Board, BoardDto>().ReverseMap();
            CreateMap<BoardCreationDto, Board>();
            CreateMap<BoardUpdateDto, Board>();

            //TaskChecklist
            CreateMap<TaskChecklist, TaskChecklistDto>().ReverseMap();
            CreateMap<TaskChecklistCreationDto, TaskChecklist>();
            CreateMap<TaskChecklistUpdateDto, TaskChecklist>().ReverseMap();

            //Status
            CreateMap<Status, StatusDto>();

            //Priority
            CreateMap<Priority, PriorityDto>();

        }
    }
}
