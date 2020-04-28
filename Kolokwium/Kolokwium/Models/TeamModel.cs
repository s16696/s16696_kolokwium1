using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models
{
    public class TeamModel
    {
        public int IdTask { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Deadline { get; set; }

        public int IdTeam { get; set; }
        public int idTaskType { get; set; }
        public int AssignedTo { get; set; }
        public int IdCreator { get; set; }
    }
}
