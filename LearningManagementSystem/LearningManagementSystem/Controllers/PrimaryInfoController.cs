using LearningManagementSystem.Models.Dto;
using LearningManagementSystem.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagementSystem.Controllers
{
    public class PrimaryInfoController : Controller
    {
        private readonly IPrimaryInfoRepository _primaryInfoRepository;

        public PrimaryInfoController(IPrimaryInfoRepository primaryInfoRepository)
        {
           this._primaryInfoRepository = primaryInfoRepository;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost("api/employee/Padd")]
        public async Task<IActionResult> Add([FromBody] PrimaryInfoDto dto)
        {
            // Check if the DTO is null
            if (dto == null)
            {
                return BadRequest(new { message = "Invalid input: DTO cannot be null." });
            }
            try
            {
                // Validate the model state
                if (!ModelState.IsValid)
                {
                    return BadRequest(new
                    {
                        message = "Validation failed.",
                        errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                    });
                }
                else
                {
                    // Attempt to add the primary info to the repository
                    await _primaryInfoRepository.addPrimaryInfo(dto);

                    // Return a success response
                    return Ok(new { message = "Added successfully!" });
                }
            }
            catch (Exception ex)
            {
                // Log the exception details if necessary (not shown here)
                // Return an error response
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "An error occurred while processing your request.", details = ex.Message });
            }
        }
    }
}
