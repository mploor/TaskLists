using System;
using System.Collections.Generic;
using System.Linq;
using TaskLists.Models;

namespace TaskLists.Models
{
    public class TaskList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TaskLists.Models.Task> Tasks { get; set; }
    }
}
