using AutoMapper;
using Entities.DTOs.Priority;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.RepositoryManager;

namespace TasklyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriorityController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public PriorityController(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPriority()
        {
            var status = await _repositoryManager.Priority.GetAllAsync();
            var statusDtos = _mapper.Map<List<PriorityDto>>(status);

            return Ok(statusDtos);

        }
    }
}
