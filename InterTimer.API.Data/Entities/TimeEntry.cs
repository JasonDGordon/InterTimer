using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterTimer.API.Data.Entities
{
    internal class TimeEntry: Audit
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public Client? Client { get; set; }
        public int ClientId { get; set; }
        public Project? Project { get; set; }
        public int ProjectId { get; set; }
        public ProjectTask? ProjectTask { get; set; }
        public int ProjectTaskId { get; set; }
        public TimeSpan TimeTaken { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
