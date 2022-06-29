using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterTimer.API.Data.Entities
{
    public class TimeEntry : Audit
    {
        public int Id { get; set; }
        public string Description { get; set; }
        
        [ForeignKey("ProjectId")]
        public Project? Project { get; set; }
        public int ProjectId { get; set; }
        
        [ForeignKey("ProjectTaskId")]
        public ProjectTask? ProjectTask { get; set; }
        public int ProjectTaskId { get; set; }

        [Column(TypeName = "bigint")]
        public TimeSpan TimeTaken { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
