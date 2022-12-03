using Medicard.Domain.Astract;
using Medicard.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

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
    }
}

