
using Medicard.Domain.Astract;
using Medicard.Domain.Entities;
using Medicard.Services.ViewModels.Institution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Services.Services
{
    public class InstitutionService : IInstitutionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InstitutionService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<AllInstitutionsViewModel> AllInstitutions()
        {
            var institutions = new List<AllInstitutionsViewModel>();
            using (var client = new HttpClient())
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7015/api/Institution");
                var response = client.SendAsync(requestMessage).Result;
                var data = response.Content.ReadAsAsync<List<Institution>>().Result;
                foreach (var institution in data)
                {
                    institutions.Add(new AllInstitutionsViewModel
                    {
                        Id = institution.Id,
                        Name = institution.Name,
                        Address = institution.Address,
                        WorkScheduleWeekendStart = institution.WorkScheduleWeekendStart,
                        WorkScheduleWeekdayEnd = institution.WorkScheduleWeekdayEnd,
                        WorkScheduleWeekdayStart = institution.WorkScheduleWeekdayStart,
                        WorkScheduleWeekendEnd = institution.WorkScheduleWeekendEnd,
                        ContactNumber = institution.ContactNumber,
                    });
                }
            }
            return institutions;
        }

        public InstitutionViewModel GetByIdReturnViewModel(int id)
        {
            var institution = _unitOfWork.GenericRepository<Institution>().GetById(id);
            return new InstitutionViewModel
            {
                Name = institution.Name,
                Address = institution.Address,
                WorkScheduleWeekendStart = institution.WorkScheduleWeekendStart,
                WorkScheduleWeekdayEnd = institution.WorkScheduleWeekdayEnd,
                WorkScheduleWeekdayStart = institution.WorkScheduleWeekdayStart,
                WorkScheduleWeekendEnd = institution.WorkScheduleWeekendEnd,
                ContactNumber = institution.ContactNumber,
            };
        }

        public async Task JoinToInstitution(Doctor currentDoctor, int id)
        {
            currentDoctor.InstitutionId = id;
            _unitOfWork.GenericRepository<Doctor>().Update(currentDoctor);
            await _unitOfWork.SaveAsync();
        }
    }
}
