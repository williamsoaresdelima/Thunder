using TaskList.Data.Entities;

namespace TaskList.Services.Interfaces
{
    public interface ITaskService
    {
        Task<TaskEntity> CreateAsync(TaskEntity task);
        Task<TaskEntity> UpdateAsync(TaskEntity task);
        Task DeleteAsync(Guid id);
        Task<List<TaskEntity>> GetAllAsync();
        Task<TaskEntity> GetByIdAsync(Guid id);
    }
}
