using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterTimer.API.Data.Entities
{
    internal class ProjectTask : Audit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProjectId { get; set; }

        [ForeignKey(Id = "ProjectId")]
        public Project? Project { get; set; }
    }
}
