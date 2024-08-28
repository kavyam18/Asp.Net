using LMS.Application.Models.Dto;
using LMS.Application.Services.Implementations;
using LMS.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Application.Controllers
{
    public class SecondaryInfoController :Controller
    {
        private readonly ISecondaryInfoRepository _secondaryInfoRepository;

        public SecondaryInfoController(ISecondaryInfoRepository secondaryInfoRepository)
        {
            _secondaryInfoRepository = secondaryInfoRepository;
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
                return BadRequest(new { message= "Error:Dto Cannot be null." });
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
                    await _secondaryInfoRepository.addSecondaryInfo(dto);
                    return Ok(new { message = "Employee Secondary Info Added Successfully!" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new {message = "Error.",details = ex.Message});
            }
        }

    }
}
