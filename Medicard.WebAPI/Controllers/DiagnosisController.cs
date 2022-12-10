using Medicard.Domain.Astract;
using Medicard.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Medicard.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosisController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public DiagnosisController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>  
        /// get all giagnosis
        /// </summary>  
        /// <param></param>  
        [HttpGet]
        public IActionResult Get()
        {
            var diagnosis = _unitOfWork.GenericRepository<Diagnosis>().GetAll();
            return Ok(diagnosis);
        }

        /// <summary>  
        /// get diagnosis by id  
        /// </summary>  
        /// <param name="id">id</param>  
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var diagnosis = _unitOfWork.GenericRepository<Diagnosis>().GetById(id);

            if (diagnosis != null)
            {
                return Ok(diagnosis);
            }

            return NotFound();
        }

        /// <summary>  
        /// delete diagnosis
        /// </summary>  
        /// <param name="id">id</param>  
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var diagnosis = _unitOfWork.GenericRepository<Diagnosis>().GetById(id);

            if (diagnosis != null)
            {
                _unitOfWork.GenericRepository<Diagnosis>().Delete(diagnosis);
                _unitOfWork.Save();
                return Ok();
            }

            return NotFound();
        }
    }
}
