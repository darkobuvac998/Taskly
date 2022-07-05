using Repositories.BoardRepository;
using Repositories.PriorityRepository;
using Repositories.StatusRepository;
using Repositories.TaskChecklistRepository;
using Repositories.TaskRepository;

namespace Repositories.RepositoryManager
{
    public interface IRepositoryManager
    {
        ITaskRepository Task { get; }
        IBoardRepository Board { get; }
        ITaskChecklistRepository TaskChecklist { get; }
        IStatusRepository Status { get; }
        IPriorityRepository Priority { get; }

        int Save();
        Task<int> SaveAsync();
    }
}
