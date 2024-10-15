using TaskList.Data.Entities;
using TaskList.Services.Interfaces;
using TaskList.Services.Services;

namespace TaskList.Services.Test
{
    public class TaskServiceTest
    {
        private readonly ITaskService _taskService;
        public TaskServiceTest()
        {
            _taskService = new TaskService();
        }

        #region Handler

        private async Task<TaskEntity> CreateAsyncTaskMock(Guid? id = null)
        {
            TaskEntity task = new TaskEntity();

            task.Mock(id);

            await _taskService.CreateAsync(task);

            return task;
        }

        #endregion


        [Fact]
        public async Task Test_Get_task_by_id()
        {
            var id = Guid.NewGuid();
            await CreateAsyncTaskMock(id);

            var result = await _taskService.GetByIdAsync(id);

            Assert.Equal(id, result.Id);

            await _taskService.DeleteAsync(id);
        }

        [Fact]
        public async Task Test_Get_all_task()
        {
            var id = Guid.NewGuid();
            await CreateAsyncTaskMock(id);

            var result = await _taskService.GetAllAsync();

            Assert.NotEmpty(result);

            await _taskService.DeleteAsync(id);
        }

        [Fact]
        public async Task Test_Create_task()
        {
            var id = Guid.NewGuid();
            await CreateAsyncTaskMock(id);

            var result = await _taskService.GetByIdAsync(id);

            Assert.Equal(id, result.Id);

            await _taskService.DeleteAsync(id);
        }

        [Fact]
        public async Task Test_Update_task()
        {
            var id = Guid.NewGuid();
            await CreateAsyncTaskMock(id);

            var resultForUpdate = await _taskService.GetByIdAsync(id);

            resultForUpdate.Title = "Test Update";

            await _taskService.UpdateAsync(resultForUpdate);

            var result = await _taskService.GetByIdAsync(id);

            Assert.Equal("Test Update", result.Title);

            await _taskService.DeleteAsync(id);
        }

        [Fact]
        public async Task Test_Delete_task()
        {
            var id = Guid.NewGuid();
            await CreateAsyncTaskMock(id);

            await _taskService.DeleteAsync(id);

            await Assert.ThrowsAsync<Exception>(() => _taskService.GetByIdAsync(id));
        }
    }
}