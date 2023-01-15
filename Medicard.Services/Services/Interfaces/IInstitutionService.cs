using Medicard.Domain.Entities;
using Medicard.Services.ViewModels.Institution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Services.Services.Interfaces
{
    public interface IInstitutionService
    {
        public IEnumerable<AllInstitutionsViewModel> AllInstitutions();
        public InstitutionViewModel GetByIdReturnViewModel(int id);
        Task JoinToInstitution(Doctor currentDoctor, int id);
    }
}
