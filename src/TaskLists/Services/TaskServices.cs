using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskLists.Models;
using TaskLists.Repository;

namespace TaskLists.Services
{
    public class TaskServices : ITaskServices
    {
        private IGenericRepository _repo;

        public TaskServices(IGenericRepository repo)
        {
            _repo = repo;
        }

        public List<Models.Task> GetTasksList()
        {
            List<TaskLists.Models.Task> Tasks = (from t in _repo.Query<Models.Task>()
                                                 select new TaskLists.Models.Task
                                                 {
                                                     Id = t.Id,
                                                     Name = t.Name,
                                                     Description = t.Description,
                                                     Status = t.Status
                                                 }).ToList();
            return Tasks;
        }

        public Models.Task GetTask(int id)
        {
            Models.Task Task = (from t in _repo.Query<Models.Task>()
                                where t.Id == id
                                select new TaskLists.Models.Task
                                {
                                    Id = t.Id,
                                    Name = t.Name,
                                    Description = t.Description,
                                    Status = t.Status
                                }).FirstOrDefault();
            return Task;
        }

        public void AddTask(TaskLists.Models.Task newTask)
        {
            TaskList taskList = new TaskList();
            taskList = (from t in _repo.Query<TaskList>()
                        where t.Id == newTask.TaskList.Id
                        select t).FirstOrDefault();
            newTask.TaskList = taskList;
            _repo.Add(newTask);
            _repo.SaveChanges();
        }

        public void UpdateTask(TaskLists.Models.Task newTask)
        {
            TaskList taskList = new TaskList();
            taskList = (from t in _repo.Query<TaskList>()
                        where t.Id == newTask.TaskList.Id
                        select t).FirstOrDefault();
            newTask.TaskList = taskList;
            _repo.Update(newTask);
            _repo.SaveChanges();
        }

        public void DeleteTask(int id)
        {
            TaskLists.Models.Task taskToDelete = (from t in _repo.Query<TaskLists.Models.Task>()
                                                  where t.Id == id
                                                  select t).FirstOrDefault();
            _repo.Delete(taskToDelete);
            _repo.SaveChanges();
        }
    }
}
