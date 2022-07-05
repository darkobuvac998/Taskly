using AutoMapper;
using Entities.DTOs.Task;
using Entities.DTOs.TaskChecklist;
using Entities.Models;
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

        /// <summary>
        /// Get tasks or get task by specified Id.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>All tasks for current user.</returns>
        /// <response code="200">Returns list of tasks</response>
        /// <response code="404">If specified task by id is not found.</response>

        [HttpGet(Name = "GetTasks")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TaskDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetTasks([FromQuery] QueryParameters parameters)
        {

            var tasks = await _repositoryManager.Task.GetByConditionAsync(parameters.FindExpression<Entities.Models.Task>(), false);
            var tasksDto = _mapper.Map<List<TaskDto>>(tasks);
            return Ok(tasksDto);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CreateTask([FromBody] TaskCreationDto taskDto)
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
            return CreatedAtRoute("GetTasks", new QueryParameters { TaskId = result.TaskId }, task);
        }

        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateTask([FromBody] TaskUpdateDto taskDto)
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
                var task = (await _repositoryManager.Task.GetByConditionAsync(task => task.TaskId == taskDto.TaskId)).FirstOrDefault();

                var checks = taskDto.TaskChecklists.ToList();
                for (int i = 0; i<taskDto.TaskChecklists.Count; i++)
                {
                    var check = checks[i];
                    if(check.TaskChecklistId == null)
                    {
                        var taskCheck = _mapper.Map<TaskChecklist>(check);
                        await _repositoryManager.TaskChecklist.CreateAsync(taskCheck);
                        checks[i] = _mapper.Map<TaskChecklistUpdateDto>(taskCheck);
                    }
                }
                taskDto.TaskChecklists = checks;

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
                if(!await _repositoryManager.Task.DeleteAsync(task.FirstOrDefault()))
                {
                    ModelState.AddModelError("", $"Something went wrong!");
                    return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
                }
                return NoContent();
            }
        }
    }
}
