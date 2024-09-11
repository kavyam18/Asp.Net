using LearningManagementSystem.Models.Dto;

namespace LearningManagementSystem.Services.Interface
{
    public interface IAddressRepository
    {
        Task addAddressDetails(AddressDtoList dto);
    }
}
