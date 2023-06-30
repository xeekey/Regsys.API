using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Regsys.API.Interfaces;
using Regsys.API.Models;
using Regsys.API.Services;

namespace Regsys.API.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var tasks = _taskService.GetAllTasks();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var task = _taskService.GetTask(id);
            if (task == null)
                return NotFound();

            return Ok(task);
        }

        [HttpPost]
        public IActionResult Post(ProjectTask task)
        {
            _taskService.AddTask(task);
            return CreatedAtAction(nameof(Get), new { id = task.TaskId }, task);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, ProjectTask task)
        {
            if (id != task.TaskId)
            {
                return BadRequest();
            }

            _taskService.UpdateTask(id, task);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _taskService.DeleteTask(id);
            return NoContent();
        }
    }

}
