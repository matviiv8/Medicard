using Medicard.Domain.Astract;
using Medicard.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Medicard.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PatientController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>  
        /// Get patients
        /// </summary>  
        /// <param></param> 
        [HttpGet]
        public IActionResult Get()
        {
            var patients = _unitOfWork.GenericRepository<Patient>().GetAll();
            return Ok(patients);
        }

        /// <summary>  
        /// Get a patient by id
        /// </summary>  
        /// <param name="id">id</param> 
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var patient = _unitOfWork.GenericRepository<Patient>().GetById(id);

            if (patient != null)
            {
                return Ok(patient);
            }

            return NotFound();
        }

        /// <summary>  
        /// delete patient
        /// </summary>  
        /// <param name="id">id</param> 
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var patient = _unitOfWork.GenericRepository<Patient>().GetById(id);

            if (patient != null)
            {
                _unitOfWork.GenericRepository<Patient>().Delete(patient);
                _unitOfWork.Save();
                return Ok();
            }

            return NotFound();
        }

        /// <summary>  
        /// add a new patient
        /// </summary>  
        /// <param name="patient">object patient</param> 
        [HttpPost]
        public IActionResult Create([FromBody] Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _unitOfWork.GenericRepository<Patient>().Add(patient);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
