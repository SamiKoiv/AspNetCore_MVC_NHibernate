using System;
using System.Collections.Generic;

namespace Entities
{
    public interface ITaskRepository
    {
        void Create(Task task);
        void Delete(Guid id);
        List<Task> GetTasks();
    }
}
