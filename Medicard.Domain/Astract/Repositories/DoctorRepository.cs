using Medicard.Domain.Concrete;
using Medicard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Domain.Astract.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor>
    {
        private readonly MedicardDbContext context = new MedicardDbContext();
        public DoctorRepository(MedicardDbContext context) : base(context)
        {
            this.context = context;
        }
        public IEnumerable<Doctor> Doctors
        {
            get { return context.Doctors; }
        }
    }
}
