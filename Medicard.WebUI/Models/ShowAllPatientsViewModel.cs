using Medicard.Services.ViewModels.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.WebUI.Models
{
    public class ShowAllPatientsViewModel
    {
        public IEnumerable<AllPatientsViewModel> AllPatients { get; set; }

        public PageViewModel PagingInfo { get; set; }
    }
}
