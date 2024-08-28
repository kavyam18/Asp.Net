using LMS.Application.Models.Dto;
using LMS.Application.Models.Entities;

namespace LMS.Application.Services.Util
{
    public class SecondaryInfoUtil
    {
        public static SecondaryInfo dtoToSecondaryEntity(SecondaryInfoDto dto)
        {
            return new SecondaryInfo
            {
                PanNo = dto.PanNo,
                AadharNo = dto.AadharNo,
                FatherName = dto.FatherName,
                MotherName = dto.MotherName,
                MaritalStatus = dto.MaritalStatus,
                PassportNo = dto.PassportNo,
                SpouseName = dto.SpouseName
            };
        }
    }
}
