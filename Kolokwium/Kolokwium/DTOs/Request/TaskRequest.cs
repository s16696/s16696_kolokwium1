using Kolokwium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.DTOs.Request
{
    public class TaskRequest
    {
        public string Name { get; set; }
        public string IdTask { get; set; }
        public string Description { get; set; }
        public DateTime DeadLine { get; set; }
        public string IdTeam { get; set; }
        public string IdAssignedTo { get; set; }
        public string IdCreator { get; set; }

        public TaskTypeModel TaskType { get; set; }
    }
}
