using LearningManagementSystem.Models.Dto;
using LearningManagementSystem.Services.Implementation;
using LearningManagementSystem.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagementSystem.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAddressRepository addressRepository;

        public AddressController(IAddressRepository addressRepository)
        {
            this.addressRepository = addressRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("api/employee/Addressadd")]
        public async Task<IActionResult> AddAddress([FromBody] AddressDtoList dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                foreach (var address in dto.AddressDetailsDtos)
                {
                    address.Address_Id = Guid.NewGuid();
                }
                await addressRepository.addAddressDetails(dto);
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


