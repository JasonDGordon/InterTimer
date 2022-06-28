using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterTimer.API.Data.Entities
{
    internal class Audit
    {
        protected DateTime CreatedAt { get; set; }
        protected DateTime LastUpdatedAt { get; set; }
    }
}
