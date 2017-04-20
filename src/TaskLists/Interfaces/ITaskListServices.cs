using System.Collections.Generic;
using TaskLists.Models;

namespace TaskLists.Services
{
    public interface ITaskListServices
    {
        void AddTaskList(string ListName);
        void DeleteTaskList(int id);
        TaskList GetTaskList(int id);
        List<TaskList> GetTaskLists();
    }
}