using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterTimer.API.Data.Entities
{
    public class Audit
    {
        protected string CreatedBy { get; set; }
        protected string UpdatedBy { get; set; }
        protected DateTime CreatedAt { get; set; }
        protected DateTime LastUpdatedAt { get; set; }
    }
}
