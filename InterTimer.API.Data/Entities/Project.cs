using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterTimer.API.Data.Entities
{
    internal class Project : Audit
    {
        internal int Id { get; set; }
        internal string Name { get; set; }
        internal int ClientId { get; set; }

        [ForeignKey(Id = "ClientId")]
        internal Client? Client { get; set; }

        internal virtual ICollection<ProjectTask>? Tasks { get; set; }

    }
}
