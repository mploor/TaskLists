using System.Collections.Generic;
using TaskLists.Models;

namespace TaskLists.Services
{
    public interface ITaskServices
    {
        void AddTask(Task newTask);
        void DeleteTask(int id);
        Task GetTask(int id);
        List<Task> GetTasksList();
        void UpdateTask(Task newTask);
    }
}