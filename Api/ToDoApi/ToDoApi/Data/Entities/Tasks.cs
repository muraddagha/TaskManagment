using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApi.Data.Entities
{
    public class Tasks
    {
        public int Id { get; set; }
        public string Node { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsDone { get; set; }
        public int CategoryId { get; set; }
        public DateTime CompletedAt { get; set; }
        public string DoneNote { get; set; }
        public Categories Categories { get; set; }

    }
}
