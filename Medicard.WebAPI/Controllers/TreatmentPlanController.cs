using Medicard.Domain.Astract;
using Medicard.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Medicard.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentPlanController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public TreatmentPlanController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>  
        /// get all treatment plans
        /// </summary>  
        /// <param></param>  
        [HttpGet]
        public IActionResult Get()
        {
            var treatmentPlans = _unitOfWork.GenericRepository<TreatmentPlan>().GetAll();
            return Ok(treatmentPlans);
        }

        /// <summary>  
        /// get treatment plan by id  
        /// </summary>  
        /// <param name="id">id</param>  
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var treatmentPlan = _unitOfWork.GenericRepository<TreatmentPlan>().GetById(id);

            if (treatmentPlan != null)
            {
                return Ok(treatmentPlan);
            }

            return NotFound();
        }

        /// <summary>  
        /// delete treatment plan
        /// </summary>  
        /// <param name="id">id</param>  
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var treatmentPlan = _unitOfWork.GenericRepository<TreatmentPlan>().GetById(id);

            if (treatmentPlan != null)
            {
                _unitOfWork.GenericRepository<TreatmentPlan>().Delete(treatmentPlan);
                _unitOfWork.Save();
                return Ok();
            }

            return NotFound();
        }
    }
}
