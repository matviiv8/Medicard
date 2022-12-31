using Medicard.Domain.Astract;
using Medicard.Domain.Entities;
using Medicard.Services.ViewModels.Admin;
using Medicard.Services.ViewModels.Institution;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Services.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;

        public AdminService(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            this._unitOfWork = unitOfWork;
            this._userManager = userManager;
        }

        public async Task CreateDoctor(CreateDoctorViewModel doctor)
        {
            if (await _userManager.FindByNameAsync(doctor.Email) == null)
            {
                var user = new User
                {
                    UserName = doctor.Email,
                    Email = doctor.Email,
                    FirstName = doctor.FirstName,
                    LastName = doctor.LastName,
                };

                var result = await _userManager.CreateAsync(user, doctor.Password);

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user,"Doctor").Wait();

                    string imageUrl;
                    if(doctor.Gender == Domain.Entities.Enums.Gender.Male)
                    {
                        imageUrl = "menunknowndoctor.jpeg";
                    }
                    else
                    {
                        imageUrl = "womenunknowndoctor.jpeg";
                    }
                    _unitOfWork.GenericRepository<Doctor>().Add(new Doctor 
                    { 
                        UserId = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Gender = doctor.Gender,
                        DoctorPicture = imageUrl,
                        Specialization = doctor.Specialization,
                        ContactNumber = doctor.ContactNumber,
                    });

                    await _unitOfWork.SaveAsync();
                }
            }
        }

        public async Task CreateInstitution(InstitutionViewModel institution)
        {
            _unitOfWork.GenericRepository<Institution>().Add(new Institution
            {
                Name = institution.Name,
                Address = institution.Address,
                WorkScheduleWeekdayStart = institution.WorkScheduleWeekdayStart,
                WorkScheduleWeekdayEnd = institution.WorkScheduleWeekdayEnd,
                WorkScheduleWeekendStart = institution.WorkScheduleWeekendStart,
                WorkScheduleWeekendEnd = institution.WorkScheduleWeekendEnd,
                ContactNumber = institution.ContactNumber,
        });

            await _unitOfWork.SaveAsync();
        }

        public async void DeleteDoctor(string id)
        {
            var user = _unitOfWork.GenericRepository<User>().GetById(id);
            var doctor = _unitOfWork.GenericRepository<Doctor>().GetAll().FirstOrDefault(d => d.UserId == id);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7015/api/");
                var deleteTask = client.DeleteAsync("Doctor/" + doctor.Id);
                deleteTask.Wait();
            }

            _userManager.RemoveFromRoleAsync(user, "Doctor");

            await _unitOfWork.SaveAsync();
        }

        public async void DeleteInstitution(int institutionId)
        {
            var institution = _unitOfWork.GenericRepository<Institution>().GetById(institutionId);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7015/api/");
                var deleteTask = client.DeleteAsync("Institution/" + institution.Id);
                deleteTask.Wait();
            }

            await _unitOfWork.SaveAsync();
        }

        public async Task ChangeInstitution(InstitutionViewModel model, int institutionId)
        {
            var institution = _unitOfWork.GenericRepository<Institution>().GetById(institutionId);

            institution.Name = model.Name;
            institution.Address = model.Address;
            institution.WorkScheduleWeekendEnd = model.WorkScheduleWeekendEnd;
            institution.WorkScheduleWeekendStart = model.WorkScheduleWeekendStart;
            institution.WorkScheduleWeekdayEnd = model.WorkScheduleWeekdayEnd;
            institution.WorkScheduleWeekdayStart = model.WorkScheduleWeekdayStart;
            institution.ContactNumber = model.ContactNumber;

            _unitOfWork.GenericRepository<Institution>().Update(institution);

            await _unitOfWork.SaveAsync();
        }
    }
}
