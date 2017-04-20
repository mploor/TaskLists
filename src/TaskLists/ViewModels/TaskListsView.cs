using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskLists.ViewModels
{
    public class TaskListsView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Models.Task> Tasks { get; set; }
    }
}
