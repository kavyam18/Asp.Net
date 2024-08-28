using LMS.Application.Models.Dto;
using LMS.Application.Models.Entities;

namespace LMS.Application.Services.Util
{
    public class PrimaryInfoUtil
    {
        public static PrimaryInfo dtoToEntity(PrimaryInfoDto dto)
        {
            return new PrimaryInfo
            {
                Employee_Id = dto.Employee_Id,
                Employee_Name = dto.Employee_Name,
                DateOfJoining = dto.DateOfJoining,
                DateOfBirth = dto.DateOfBirth,
                Email = dto.Email,
                BloodGroup = dto.BloodGroup,
                Designation = dto.Designation,
                Gender = dto.Gender,
                Nationality = dto.Nationality,
                EmployeeStatus = dto.EmployeeStatus
            };
        }
    }
}
