using Microsoft.AspNetCore.Mvc;
using TaskList.Data.Entities;
using TaskList.Services.Interfaces;

namespace TaskList.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {

        private readonly ITaskService _service;

        public TaskController(ITaskService service)
        {
            _service = service;
        }

        [HttpGet()]
        public async Task<List<TaskEntity>> GetAll() => await _service.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<TaskEntity> GetById(Guid id) => await _service.GetByIdAsync(id);

        [HttpPost()]
        public async Task<TaskEntity> Create(TaskEntity task) => await _service.CreateAsync(task);

        [HttpPut()]
        public async Task<TaskEntity> Update(TaskEntity task) => await _service.UpdateAsync(task);

        [HttpDelete("{id}")]
        public async Task Delete(Guid id) => await _service.DeleteAsync(id);
    }
}
