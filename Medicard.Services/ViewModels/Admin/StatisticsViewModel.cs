using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Services.ViewModels.Admin
{
    public class StatisticsViewModel
    {
        public int UsersCount { get; set; }

        public int DoctorsCount { get; set; }

        public int PatientsCount { get; set; }
    }
}
