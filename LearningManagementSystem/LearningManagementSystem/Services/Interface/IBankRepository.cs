using LearningManagementSystem.Models.Dto;

namespace LearningManagementSystem.Services.Interface
{
    public interface IBankRepository
    {
        Task addBankDetails(BankDtoList dto);
    }
}
