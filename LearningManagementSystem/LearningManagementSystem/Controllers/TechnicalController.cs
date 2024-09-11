using LearningManagementSystem.Models.Dto;
using LearningManagementSystem.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagementSystem.Controllers
{
    public class TechnicalController : Controller
    {
        private readonly ITechnicalSkillRepository technicalSkillRepository;

        public TechnicalController(ITechnicalSkillRepository technicalSkillRepository)
        {
            this.technicalSkillRepository = technicalSkillRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("api/employee/Technicaladd")]
        public async Task<IActionResult> AddTechnicalSkill([FromBody] TechnicalSkillDtoList dtoList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                // Generate IDs for new technical skills
               
                    foreach (var technical in dtoList.TechnicalSkillDtos)
                    {
                        technical.Technical_Id = Guid.NewGuid();
                    }
                
                // Call repository method to handle the business logic
                await technicalSkillRepository.addTechnicalSkill(dtoList);
                return Ok(new { message = "Technical skills added successfully!" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "An error occured while processing your request.", details = ex.Message }); ;
            }
        }
    }
}
