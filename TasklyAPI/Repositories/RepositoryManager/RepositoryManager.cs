using Entities.Data;
using Repositories.BoardRepository;
using Repositories.PriorityRepository;
using Repositories.StatusRepository;
using Repositories.TaskChecklistRepository;
using Repositories.TaskRepository;

namespace Repositories.RepositoryManager
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IBoardRepository _boardRepository;
        private readonly IStatusRepository _statusRepository;
        private readonly ITaskChecklistRepository _taskChecklistRepository;
        private readonly IPriorityRepository _priorityRepository;
        private readonly TasklyDbContext _context;


        public RepositoryManager(
            ITaskRepository taskRepository,
            IBoardRepository boardRepository,
            IStatusRepository statusRepository,
            ITaskChecklistRepository taskChecklistRepository,
            IPriorityRepository priorityRepository,
            TasklyDbContext context
            )
        {
            _taskRepository = taskRepository;
            _boardRepository = boardRepository;
            _statusRepository = statusRepository;
            _taskChecklistRepository = taskChecklistRepository;
            _priorityRepository = priorityRepository;
            _context = context;
        }

        public ITaskRepository Task { get { return _taskRepository; } }

        public IBoardRepository Board { get { return _boardRepository; } }

        public ITaskChecklistRepository TaskChecklist { get { return _taskChecklistRepository; } }

        public IStatusRepository Status { get { return _statusRepository; } }

        public IPriorityRepository Priority { get { return _priorityRepository; } }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
