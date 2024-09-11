using LearningManagementSystem.Models.Dto;
using LearningManagementSystem.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagementSystem.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }
        [HttpPost("api/employee/Contactadd")]
        public async Task<IActionResult> AddContact([FromBody] ContactDtoList dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                foreach (var contact in dto.ContactDetailsDtos)
                {
                    contact.Contact_Id = Guid.NewGuid();
                }
                await contactRepository.addContactDetails(dto);
                return Ok(new { message = "Added Successfully!" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new {message = "An error occured while processing your request.", details = ex.Message});
            }
        }
    }
}
