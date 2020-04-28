using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models
{
    public class TaskModel
    {
        public string IdTask { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public string IdTeam { get; set; }
/*        public int IdTaskType { get; set; }
        public int IdAssignedTo { get; set; }*/
        public string IdCreator { get; set; }

        public string czyJestKreatorem { get; set; }



    }
}
