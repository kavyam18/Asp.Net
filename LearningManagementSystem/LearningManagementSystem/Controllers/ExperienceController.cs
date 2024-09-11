using LearningManagementSystem.Models.Dto;
using LearningManagementSystem.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagementSystem.Controllers
{
    public class ExperienceController : Controller
    {
        private readonly IExperienceRepository experienceRepository;

        public ExperienceController(IExperienceRepository experienceRepository)
        {
            this.experienceRepository = experienceRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("api/employee/Experienceadd")]
        public async Task<IActionResult> CreateExperience([FromBody] ExperienceDtoList dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                foreach (var experience in dto.ExperienceDetailsDtos)
                {
                    experience.Experience_Id = Guid.NewGuid();
                }
                await experienceRepository.addExperienceDetails(dto);
                return Ok(new { message = "Added Successfully!" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "An error occured while processing your request.", details = ex.Message });
            }
        }
    }
}
