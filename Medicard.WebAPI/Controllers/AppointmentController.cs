using Medicard.Domain.Astract;
using Medicard.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Medicard.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AppointmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>  
        /// get all appointments
        /// </summary>  
        /// <param></param>  
        [HttpGet]
        public IActionResult Get()
        {
            var appointments = _unitOfWork.GenericRepository<Appointment>().GetAll();
            return Ok(appointments);
        }

        /// <summary>  
        /// get appointment by id  
        /// </summary>  
        /// <param name="id">id</param>  
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var appointment = _unitOfWork.GenericRepository<Appointment>().GetById(id);

            if (appointment != null)
            {
                return Ok(appointment);
            }

            return NotFound();
        }

        /// <summary>  
        /// delete  appointment
        /// </summary>  
        /// <param name="id">id</param>  
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var appointment = _unitOfWork.GenericRepository<Appointment>().GetById(id);

            if (appointment != null)
            {
                _unitOfWork.GenericRepository<Appointment>().Delete(appointment);
                _unitOfWork.Save();
                return Ok();
            }

            return NotFound();
        }
    }
}
