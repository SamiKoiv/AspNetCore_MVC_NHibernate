using System;

namespace Entities
{
    public class Task
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? DoneDate { get; set; }
    }
}
