using Medicard.Domain.Astract;
using Medicard.Domain.Entities;
using Medicard.Services.Services.Interfaces;
using Medicard.Services.ViewModels.Admin;
using Medicard.Services.ViewModels.Institution;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Services.Services.Implementations
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;

        public AdminService(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
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
                    _userManager.AddToRoleAsync(user, "Head doctor").Wait();

                    string imageUrl;
                    if (doctor.Gender == Domain.Entities.Enums.Gender.Male)
                    {
                        imageUrl = "menunknowndoctor.jpeg";
                    }
                    else
                    {
                        imageUrl = "womenunknowndoctor.jpeg";
                    }

                    var newDoctor = new Doctor
                    {
                        UserId = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Gender = doctor.Gender,
                        DoctorPicture = imageUrl,
                        Specialization = doctor.Specialization,
                        ContactNumber = doctor.ContactNumber,
                        ScheduleId = 1,
                    };

                    _unitOfWork.GenericRepository<Doctor>().Add(newDoctor);

                    if (doctor.IsHeadDoctor == true)
                    {
                        _unitOfWork.GenericRepository<HeadDoctor>().Add(new HeadDoctor
                        {
                            DoctorId = newDoctor.Id,
                            Doctor = newDoctor,
                        });
                    }

                    await _unitOfWork.SaveAsync();
                }
            }
        }

        public async Task CreateInstitution(InstitutionViewModel institution)
        {
            var newInstitution = new Institution
            {
                Name = institution.Name,
                Address = institution.Address,
                WorkScheduleWeekdayStart = institution.WorkScheduleWeekdayStart,
                WorkScheduleWeekdayEnd = institution.WorkScheduleWeekdayEnd,
                WorkScheduleWeekendStart = institution.WorkScheduleWeekendStart,
                WorkScheduleWeekendEnd = institution.WorkScheduleWeekendEnd,
                ContactNumber = institution.ContactNumber,
            };

            var currentHeadDoctor = _unitOfWork.GenericRepository<HeadDoctor>().GetById(institution.HeadDoctorId);
            if (currentHeadDoctor != null)
            {
                currentHeadDoctor.InstitutionId = institution.Id;

                newInstitution.HeadDoctor = currentHeadDoctor;
                _unitOfWork.GenericRepository<HeadDoctor>().Update(currentHeadDoctor);
            }

            _unitOfWork.GenericRepository<Institution>().Add(newInstitution);
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
            _userManager.DeleteAsync(user);

            _unitOfWork.SaveAsync();
        }

        public async void DeleteHeadDoctor(string id)
        {
            var user = _unitOfWork.GenericRepository<User>().GetById(id);
            var doctor = _unitOfWork.GenericRepository<Doctor>().GetAll().FirstOrDefault(d => d.UserId == id);
            var headDoctor = _unitOfWork.GenericRepository<HeadDoctor>().GetById(doctor.HeadDoctor.Id);

            DeleteDoctor(id);

            _unitOfWork.GenericRepository<HeadDoctor>().Delete(headDoctor);

            _userManager.RemoveFromRoleAsync(user, "Head doctor");
            await _unitOfWork.SaveAsync();
        }

        public async void DeleteInstitution(int institutionId)
        {
            var institution = _unitOfWork.GenericRepository<Institution>().GetById(institutionId);
            var headDoctor = _unitOfWork.GenericRepository<HeadDoctor>().GetAll().Where(headDoctor => headDoctor.InstitutionId == institutionId).FirstOrDefault();

            if(headDoctor != null)
            {
                headDoctor.InstitutionId = null;
                headDoctor.Institution = null;
                institution.HeadDoctor = null;

                _unitOfWork.GenericRepository<HeadDoctor>().Update(headDoctor);
                _unitOfWork.GenericRepository<Institution>().Update(institution);
                _unitOfWork.Save();
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7015/api/");
                var deleteTask = client.DeleteAsync("Institution/" + institutionId);
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
