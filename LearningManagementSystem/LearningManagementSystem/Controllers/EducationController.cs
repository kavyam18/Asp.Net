using LearningManagementSystem.Models.Dto;
using LearningManagementSystem.Services.Implementation;
using LearningManagementSystem.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagementSystem.Controllers
{
    public class EducationController : Controller
    {
        private readonly IEducationRepository educationRepository;

        public EducationController(IEducationRepository educationRepository)
        {
            this.educationRepository = educationRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("api/employee/Eadd")]
        public async Task<IActionResult> CreateEducation([FromBody] EducationDtoList dto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList();
                return BadRequest(new { message = "Invalid request data", errors });
            }
            try
            {
                foreach (var education in dto.EducationDetailsDtos)
                {
                    education.Education_Id = Guid.NewGuid();
                }
                await educationRepository.addEducationDetails(dto);
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
