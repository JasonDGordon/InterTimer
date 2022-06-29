﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterTimer.API.Data.Entities
{
    public class ProjectTask : Audit
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
