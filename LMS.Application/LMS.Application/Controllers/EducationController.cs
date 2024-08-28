using LMS.Application.Models.Dto;
using LMS.Application.Services.Implementations;
using LMS.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Application.Controllers
{
    public class EducationController : Controller
    {

        private readonly IEducationRepository _educationRepository;

        public EducationController(IEducationRepository educationRepository)
        {
            _educationRepository = educationRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("api/employee/Eadd")]
        public async Task<IActionResult> CreateEducation([FromBody] EducationDetailsListDto dto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList();
                return BadRequest(new { message = "Invalid request data", errors });
            }
            try
            {
                foreach (var education in dto.EducationDetailsList)
                {
                    education.Education_Id = Guid.NewGuid();
                }
                await _educationRepository.addEducationDetails(dto);
                return Ok(new { message = "Added Successfully!" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new {message = "An error occured while processing your request.", details = ex.Message});   
            }
        }
    }
}
