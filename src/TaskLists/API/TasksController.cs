using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskLists.Data;
using TaskLists.Models;
using TaskLists.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskLists.API
{
    [Route("api/[controller]")]
    public class TasksController : Controller
    {
        private ITaskServices _taskService;

        public TasksController(ITaskServices taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public List<TaskLists.Models.Task> Get()
        {
            return _taskService.GetTasksList();
        }

        [HttpPost]
        public IActionResult Post([FromBody]TaskLists.Models.Task newTask)
        {
            if (newTask == null)
            {
                return BadRequest();
            }
            else if (newTask.Id == 0)
            {
                _taskService.AddTask(newTask);
                return Ok();
            }
            else
            {
                _taskService.UpdateTask(newTask);
                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _taskService.DeleteTask(id);
            return Ok();
        }
    }
}
