using LearningManagementSystem.Models.Dto;
using LearningManagementSystem.Services.Implementation;
using LearningManagementSystem.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagementSystem.Controllers
{
    public class SecondaryInfoController : Controller
    {
        private readonly ISecondaryInfoRepository secondaryInfoRepository;

        public SecondaryInfoController(ISecondaryInfoRepository secondaryInfoRepository)
        {
            this.secondaryInfoRepository = secondaryInfoRepository;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost("api/employee/Sadd")]
        public async Task<IActionResult> AddSecond([FromBody] SecondaryInfoDto dto)
        {
            if (dto == null)
            {
                return BadRequest(new { message = "Error:Dto Cannot be null." });
            }
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new
                    {
                        message = "Validation failed.",
                        errors = ModelState.Values.SelectMany(x => x.Errors).Select(e => e.ErrorMessage)
                    });
                }
                else
                {
                    await secondaryInfoRepository.addSecondaryInfo(dto);
                    return Ok(new { message = "Employee Secondary Info Added Successfully!" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "Error.", details = ex.Message });
            }
        }
    }
}
