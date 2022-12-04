using Medicard.Domain.Astract;
using Medicard.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Medicard.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DoctorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>  
        /// get all doctors
        /// </summary>  
        /// <param></param>  
        [HttpGet]
        public IActionResult Get()
        {
            var doctors = _unitOfWork.GenericRepository<Doctor>().GetAll();
            return Ok(doctors);
        }

        /// <summary>  
        /// get doctor by id  
        /// </summary>  
        /// <param name="id">id</param>  
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var doctor = _unitOfWork.GenericRepository<Doctor>().GetById(id);

            if (doctor != null)
            {
                return Ok(doctor);
            }

            return NotFound();
        }

        /// <summary>  
        /// delete doctor  
        /// </summary>  
        /// <param name="id">id</param>  
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _unitOfWork.GenericRepository<Doctor>().GetById(id);

            if(entity != null)
            {
                _unitOfWork.GenericRepository<Doctor>().Delete(entity);
                _unitOfWork.Save();
                return Ok();
            }

            return NotFound();
        }
        /// <summary>  
        /// update doctor 
        /// </summary>  
        /// <param name="id">id</param>  
        /// <param name="doctor">object doctor</param> 
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Doctor doctor)
        {
            if (doctor == null)
            {
                return BadRequest();
            }
            if (!_unitOfWork.GenericRepository<Doctor>().GetAll().Any(x => x.Id == id))
            {
                return NotFound();
            }

            var newDoctor = new Doctor()
            {
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                ContactNumber = doctor.ContactNumber,
                Age = doctor.Age,
                Specialization = doctor.Specialization,
                Gender = doctor.Gender,
                DoctorPicture = doctor.DoctorPicture,
            };
            _unitOfWork.GenericRepository<Doctor>().Update(newDoctor);
            await _unitOfWork.SaveAsync();
            return Ok(newDoctor);
        }
    }
}

