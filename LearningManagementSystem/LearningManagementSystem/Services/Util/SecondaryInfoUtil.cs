using LearningManagementSystem.Models.Dto;
using LearningManagementSystem.Models.Entity;

namespace LearningManagementSystem.Services.Util
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
