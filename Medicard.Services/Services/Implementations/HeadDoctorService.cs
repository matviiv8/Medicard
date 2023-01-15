using Medicard.Domain.Astract;
using Medicard.Domain.Entities;
using Medicard.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Services.Services.Implementations
{
    public class HeadDoctorService : IHeadDoctorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public HeadDoctorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<HeadDoctor> AllHeadDoctors()
        {
            return _unitOfWork.GenericRepository<HeadDoctor>().GetAll();
        }
    }
}
