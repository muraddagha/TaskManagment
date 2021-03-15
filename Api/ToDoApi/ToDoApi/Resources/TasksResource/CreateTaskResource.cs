using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApi.Resources.TasksResource
{
    public class CreateTaskResource
    {
        [Required]
        [MaxLength(50)]
        public string Node { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [MaxLength(200)]
        public string DoneNote { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public DateTime CompletedAt { get; set; }

        [Required]
        public bool IsDone { get; set; }
    }
}
