using Medicard.Domain.Astract;
using Medicard.Domain.Entities;
using Medicard.Services.Services.Interfaces;
using Medicard.Services.ViewModels.Institution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Services.Services.Implementations
{
    public class InstitutionService : IInstitutionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InstitutionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
                    var currentInstitution = new AllInstitutionsViewModel
                    {
                        Id = institution.Id,
                        Name = institution.Name,
                        Address = institution.Address,
                        WorkScheduleWeekendStart = institution.WorkScheduleWeekendStart,
                        WorkScheduleWeekdayEnd = institution.WorkScheduleWeekdayEnd,
                        WorkScheduleWeekdayStart = institution.WorkScheduleWeekdayStart,
                        WorkScheduleWeekendEnd = institution.WorkScheduleWeekendEnd,
                        ContactNumber = institution.ContactNumber,
                    };
                    var currentHeadDoctor = _unitOfWork.GenericRepository<HeadDoctor>().GetAll().Where(headDoctor => headDoctor.InstitutionId == institution.Id).FirstOrDefault();
                    
                    if (currentHeadDoctor != null)
                    {
                        currentInstitution.HeadDoctorFullName = _unitOfWork.GenericRepository<Doctor>().GetAll().Where(doctor => doctor.Id == currentHeadDoctor.DoctorId).FirstOrDefault().ToString();
                    }

                    institutions.Add(currentInstitution);
                }
            }
            return institutions;
        }

        public InstitutionViewModel GetByIdReturnViewModel(int id)
        {
            var institution = _unitOfWork.GenericRepository<Institution>().GetById(id);
            return new InstitutionViewModel
            {
                Id = institution.Id,
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
