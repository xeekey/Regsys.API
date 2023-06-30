using Regsys.API.Models;

namespace Regsys.API.Interfaces
{
    public interface ITaskService
    {
        IEnumerable<ProjectTask> GetAllTasks();
        ProjectTask GetTask(int id);
        void AddTask(ProjectTask task);
        void UpdateTask(int id, ProjectTask task);
        void DeleteTask(int id);
    }

}
