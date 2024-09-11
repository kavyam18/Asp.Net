using LearningManagementSystem.Models.Dto;
using LearningManagementSystem.Models.Entity;

namespace LearningManagementSystem.Services.Util
{
    public class BankUtil
    {
        public static List<BankDetail> dtoToBank(List<BankDetailsDto> dtos, Guid PrimaryInfoId)
        {
            return dtos.Select(dto => new BankDetail
            {
                BankName = dto.BankName,
                AccountNo = dto.AccountNo,
                AccountType = dto.AccountType,
                Branch = dto.Branch,
                IFSC_Code = dto.IFSC_Code,
                State = dto.State,
                PrimaryInfoId = PrimaryInfoId
            }).ToList();
        }
    }
}
