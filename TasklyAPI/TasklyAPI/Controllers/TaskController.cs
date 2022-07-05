using AutoMapper;
using Entities.DTOs.Task;
using Entities.QueryParameters;
using Microsoft.AspNetCore.Mvc;
using Repositories.RepositoryManager;

namespace TasklyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public TaskController(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetTaskById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TaskDto))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetTasks([FromQuery] QueryParameters parameters)
        {
            if(parameters.TaskId != null)
            {
                var task = await _repositoryManager.Task.GetByConditionAsync(task => task.TaskId == parameters.TaskId, trackChanges: false);
                if (task == null)
                {
                    return NoContent();
                }
                var taskDto = _mapper.Map<TaskDto>(task);
                return Ok(taskDto);
            }
            else
            {
                var tasks = await _repositoryManager.Task.GetAllAsync(trackChanges: false);
                var tasksDto = _mapper.Map<List<TaskDto>>(tasks);
                return Ok(tasksDto);
            }
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Task))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CreateTask([FromBody] TaskDto taskDto)
        {
            if (taskDto == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var task = _mapper.Map<Entities.Models.Task>(taskDto);
            var result = await _repositoryManager.Task.CreateAsync(task);
            return CreatedAtRoute("GetTaskById", new QueryParameters { TaskId = result.TaskId }, task);
        }

        [HttpPut]
        [ProducesResponseType(201, Type = typeof(Task))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateTask([FromBody] TaskDto taskDto)
        {
            if (taskDto == null)
            {
                return BadRequest(ModelState);  
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(! await _repositoryManager.Task.TaskExistsAsync(task => task.TaskId == taskDto.TaskId))
            {
                ModelState.AddModelError("", $"There is no task with id {taskDto.TaskId}");
                return BadRequest(ModelState);
            }
            else
            {
                var task = _repositoryManager.Task.GetByCondition(task => task.TaskId == taskDto.TaskId);
                _mapper.Map(taskDto, task);
                await _repositoryManager.SaveAsync();

                return NoContent();
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteTask([FromQuery] QueryParameters parameters)
        {
            if(! await _repositoryManager.Task.TaskExistsAsync(task => task.TaskId == parameters.TaskId))
            {
                return NotFound();
            }
            else
            {
                var task = await _repositoryManager.Task.GetByConditionAsync(task => task.TaskId == parameters.TaskId);
                if(!await _repositoryManager.Task.DeleteAsync(task))
                {
                    ModelState.AddModelError("", $"Something went wrong!");
                    return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
                }
                return NoContent();
            }
        }
    }
}
