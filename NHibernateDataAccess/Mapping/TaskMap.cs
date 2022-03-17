using FluentNHibernate.Mapping;
using NHibernateDataAccess.Entities;

namespace NHibernateDataAccess.Mapping
{
    internal class TaskMap : ClassMap<Task>
    {
        public TaskMap()
        {
            Table("Tasks");
            Id(x => x.Id);
            Map(x => x.Name)
                .Length(255)
                .Not.Nullable();
            Map(x => x.CreatedDate)
                .Not.Update().CustomType("UtcDateTime")
                .ReadOnly()
                .Generated.Insert();
            Map(x => x.DoneDate);
        }
    }
}
