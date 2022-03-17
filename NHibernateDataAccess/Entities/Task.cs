using System;

namespace NHibernateDataAccess.Entities
{
    public class Task
    {
        public virtual Guid Id { get; protected set; }
        public virtual string Name { get; set; }
        public virtual DateTime? CreatedDate { get; set; }
        public virtual DateTime? DoneDate { get; set; }
    }
}
