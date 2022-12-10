using Medicard.Domain.Astract;
using Medicard.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Medicard.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstitutionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public InstitutionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>  
        /// get all institutions
        /// </summary>  
        /// <param></param>  
        [HttpGet]
        public IActionResult Get()
        {
            var institutions = _unitOfWork.GenericRepository<Institution>().GetAll();
            return Ok(institutions);
        }

        /// <summary>  
        /// get institution by id  
        /// </summary>  
        /// <param name="id">id</param>  
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var institution = _unitOfWork.GenericRepository<Institution>().GetById(id);

            if (institution != null)
            {
                return Ok(institution);
            }

            return NotFound();
        }

        /// <summary>  
        /// delete institution
        /// </summary>  
        /// <param name="id">id</param>  
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var institution = _unitOfWork.GenericRepository<Institution>().GetById(id);

            if (institution != null)
            {
                _unitOfWork.GenericRepository<Institution>().Delete(institution);
                _unitOfWork.Save();
                return Ok();
            }

            return NotFound();
        }
    }
}
