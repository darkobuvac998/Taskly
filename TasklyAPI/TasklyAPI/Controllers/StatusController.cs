using AutoMapper;
using Entities.DTOs.Status;
using Microsoft.AspNetCore.Mvc;
using Repositories.RepositoryManager;

namespace TasklyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public StatusController(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetStatus()
        {
            var status = await _repositoryManager.Status.GetAllAsync();
            var statusDtos = _mapper.Map<List<StatusDto>>(status);

            return Ok(statusDtos);

        }
    }
}
