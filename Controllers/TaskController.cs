using TodoList.Models;
using TodoList.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TodoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TasksService _tasksService;

        public TaskController(TasksService tasksService) {
            _tasksService = tasksService;
        }

        [HttpGet]
        public ActionResult<List<Task>> Get() =>
            _tasksService.Get();

        [HttpGet("{id:length(24)}", Name = "GetTask")]
        public ActionResult<Task> Get(string id) {
            var task = _tasksService.Get(id);

            if(task == null)
                return NotFound();

            return task;
        }

        [HttpPost]
        public ActionResult<Task> Create(Task task) {
            _tasksService.Create(task);
            return CreatedAtRoute("GetTask", new { id = task.Id.ToString() }, task);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Task taskIn) {
            var task = _tasksService.Get(id);

            if(task == null) 
                return NotFound();

            _tasksService.Update(id, taskIn);

            return NoContent();
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Delete(string id) {
            var task = _tasksService.Get(id);

            if(task == null)
                return NotFound();

            _tasksService.Remove(task.Id);

            return NoContent();
        }
    }
}