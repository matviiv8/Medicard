using Medicard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Services.Services.Interfaces
{
    public interface IHeadDoctorService
    {
        public IEnumerable<HeadDoctor> AllHeadDoctors();

        public HeadDoctor GetByUserId(string userId);
    }
}
