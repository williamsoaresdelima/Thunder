using Microsoft.EntityFrameworkCore;
using TaskList.Data.Context;
using TaskList.Data.Entities;
using TaskList.Services.Interfaces;

namespace TaskList.Services.Services
{
    public class TaskService : ITaskService
    {
        private readonly ContextDb db = new(null);

        public async Task<TaskEntity> CreateAsync(TaskEntity task)
        {
            await db.Task.AddAsync(task);
            await db.SaveChangesAsync();

            return task;
        }

        public async Task<TaskEntity> UpdateAsync(TaskEntity task)
        {
            var taskUpdate = await db.Task.FirstOrDefaultAsync(x => x.Id == task.Id);

            if (taskUpdate is null)
                throw new Exception("Task not found!");

            taskUpdate.StartDate = task.StartDate;
            taskUpdate.EndDate = task.EndDate;
            taskUpdate.Status = task.Status;    
            taskUpdate.Description = task.Description;
            taskUpdate.Title = task.Title;

            db.Entry(taskUpdate).State = EntityState.Modified;
            await db.SaveChangesAsync();

            return taskUpdate;
        }

        public async Task DeleteAsync(Guid id)
        {
            var task = await db.Task.FirstOrDefaultAsync(x => x.Id == id);

            if (task is null)
                throw new Exception("Task not found!");

            db.Remove(task);
            await db.SaveChangesAsync();
        }

        public async Task<List<TaskEntity>> GetAllAsync() => await db.Task.ToListAsync();

        public async Task<TaskEntity> GetByIdAsync(Guid id)
        {
            var task = await db.Task.FirstOrDefaultAsync(x => x.Id == id);

            if (task is null)
                throw new Exception("Task not found!");

            return task;
        }
    }
}
