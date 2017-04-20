using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskLists.ViewModels;
using TaskLists.Data;
using TaskLists.Models;
using TaskLists.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskLists.API
{
    [Route("api/[controller]")]
    public class TaskListsController : Controller
    {
        private ITaskListServices _listService;

        public TaskListsController(ITaskListServices listService)
        {
            _listService = listService;
        }

        [HttpGet]
        public List<TaskList> Get()
        {
            return _listService.GetTaskLists();
        }

        [HttpPost]
        public IActionResult Post([FromBody]string ListName)
        {
            _listService.AddTaskList(ListName);
            return Ok();
        }
    }
}
