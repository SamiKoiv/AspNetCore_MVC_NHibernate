using Entities;
using NHibernateDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Task = NHibernateDataAccess.Entities.Task;

namespace NHibernateDataAccess.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private NHibernateRepository _repositoryBase = new NHibernateRepository();

        public void Delete(Guid id)
        {
            _repositoryBase.Delete<Task>(id);
        }

        public List<global::Entities.Task> GetTasks()
            => _repositoryBase.Get<Task>()
            .Select(x =>
            {
                var task = new global::Entities.Task()
                {
                    Id = x.Id,
                    Name = x.Name,
                    CreatedDate = x.CreatedDate,
                    DoneDate = x.DoneDate
                };

                return task;
            })
            .ToList();

        public void Create(global::Entities.Task task)
        {
            var convertedTask = new Task()
            {
                Name = task.Name,
                CreatedDate = task.CreatedDate,
                DoneDate = task.DoneDate
            };

            _repositoryBase.Save<Task>(convertedTask);
        }
    }
}
