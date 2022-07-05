using AutoMapper;
using Entities.DTOs.Board;
using Entities.Models;
using Entities.QueryParameters;
using Microsoft.AspNetCore.Mvc;
using Repositories.RepositoryManager;

namespace TasklyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public BoardController(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        /// <summary>
        /// Get boards for user.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [HttpGet(Name = "GetBoards")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<BoardDto>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetBoards([FromQuery] QueryParameters parameters)
        {
            var boards = await _repositoryManager.Board.GetByConditionAsync(parameters.FindExpression<Board>(), trackChanges: false);
            var boardsDto = _mapper.Map<List<BoardDto>>(boards);
            return Ok(boardsDto);
        }

        /// <summary>
        /// Create new board.
        /// </summary>
        /// <param name="boardDto"></param>
        /// <returns></returns>

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(BoardDto))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CreateBoard([FromBody] BoardCreationDto boardDto)
        {
            if (boardDto == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var board = _mapper.Map<Board>(boardDto);
            var result = await _repositoryManager.Board.CreateAsync(board);
            return CreatedAtRoute("GetTasks", new QueryParameters { BoardId = result.BoardId }, board);
        }

        /// <summary>
        /// Update board.
        /// </summary>
        /// <param name="boardDto"></param>
        /// <returns></returns>

        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateBoard([FromBody] BoardUpdateDto boardDto)
        {
            if (boardDto == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await _repositoryManager.Board.BoardExistsAsync(board => board.BoardId == boardDto.BoardId))
            {
                ModelState.AddModelError("", $"There is no board with id {boardDto.BoardId}");
                return BadRequest(ModelState);
            }
            else
            {
                var board = await _repositoryManager.Board.GetByConditionAsync(board => board.BoardId == boardDto.BoardId);
                _mapper.Map(boardDto, board);
                await _repositoryManager.SaveAsync();

                return NoContent();
            }
        }

        /// <summary>
        /// Delete board.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteBoard([FromQuery] QueryParameters parameters)
        {
            if (!await _repositoryManager.Board.BoardExistsAsync(board => board.BoardId == parameters.BoardId))
            {
                return NotFound();
            }
            else
            {
                var board = await _repositoryManager.Board.GetByConditionAsync(board => board.BoardId == parameters.BoardId);
                if (!await _repositoryManager.Board.DeleteAsync(board.FirstOrDefault()))
                {
                    ModelState.AddModelError("", $"Something went wrong!");
                    return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
                }
                return NoContent();
            }
        }
    }
}
