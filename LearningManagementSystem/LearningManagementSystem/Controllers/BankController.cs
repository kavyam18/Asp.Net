using LearningManagementSystem.Models.Dto;
using LearningManagementSystem.Services.Implementation;
using LearningManagementSystem.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagementSystem.Controllers
{
    public class BankController : Controller
    {
        private readonly IBankRepository bankRepository;

        public BankController(IBankRepository bankRepository)
        {
            this.bankRepository = bankRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("api/employee/Bankadd")]
        public async Task<IActionResult> AddAddress([FromBody] BankDtoList dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                foreach (var bank in dto.BankDetailsDtos)
                {
                    bank.Bank_Id = Guid.NewGuid();
                }
                await bankRepository.addBankDetails(dto);
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


