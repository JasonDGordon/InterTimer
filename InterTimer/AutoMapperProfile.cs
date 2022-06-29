using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace InterTimer.API
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Domain.Request.ClientRequest, Data.Entities.Client>();
            CreateMap<Domain.Request.ClientUpdateRequest, Data.Entities.Client>();
            CreateMap<Domain.Request.ProjectRequest, Data.Entities.Project>();
        }
    }
}
