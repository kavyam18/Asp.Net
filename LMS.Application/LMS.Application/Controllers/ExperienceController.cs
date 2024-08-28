using LMS.Application.Models.Dto;
using LMS.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Application.Controllers
{
    public class ExperienceController : Controller
    {
        private readonly IExperienceRepository _experienceRepository;

        public ExperienceController(IExperienceRepository experienceRepository)
        {
            _experienceRepository = experienceRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateExperience([FromBody] ExperienceDtoList dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                foreach (var experience in dto.ExperienceDetails)
                {
                    experience.Experience_Id = Guid.NewGuid();
                }
                await _experienceRepository.addExperienceDetails(dto);
                return Ok(new { message = "Added Successfully!" });
            }
            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, 
                new { message = "An error occured while processing your request.", details = ex.Message });
            }

        }
}
