using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskLists.Models;
using TaskLists.Repository;

namespace TaskLists.Services
{
    public class TaskListServices : ITaskListServices
    {
        private IGenericRepository _repo;

        public TaskListServices(IGenericRepository repo)
        {
            _repo = repo;
        }

        public List<TaskList> GetTaskLists()
        {
            List<TaskList> TaskLists = (from t in _repo.Query<TaskList>()
                                        select new TaskList
                                        {
                                            Id = t.Id,
                                            Name = t.Name,
                                            Tasks = t.Tasks
                                        }).ToList();
            return TaskLists;
        }

        public TaskList GetTaskList(int id)
        {
            TaskList TaskList = (from t in _repo.Query<TaskList>()
                                 where t.Id == id
                                 select new TaskList
                                 {
                                     Id = t.Id,
                                     Name = t.Name,
                                     Tasks = t.Tasks
                                 }).FirstOrDefault();
            return TaskList;
        }

        public void AddTaskList(string ListName)
        {
            TaskList newTaskList = new TaskList();
            newTaskList.Name = ListName;
            _repo.Add(newTaskList);
            _repo.SaveChanges();
        }

        public void DeleteTaskList(int id)
        {
            TaskList delList = GetTaskList(id);
            _repo.Delete(delList);
        }
    }
}
