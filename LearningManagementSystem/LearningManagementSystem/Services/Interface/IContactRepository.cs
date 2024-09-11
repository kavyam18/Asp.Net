using LearningManagementSystem.Models.Dto;

namespace LearningManagementSystem.Services.Interface
{
    public interface IContactRepository
    {
        Task addContactDetails(ContactDtoList dto);
    }
}
