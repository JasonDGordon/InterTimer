using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterTimer.API.Domain.Request
{
    public class ProjectUpdateRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
