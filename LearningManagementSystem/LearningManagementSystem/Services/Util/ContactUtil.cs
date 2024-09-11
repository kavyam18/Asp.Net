using LearningManagementSystem.Models.Dto;
using LearningManagementSystem.Models.Entity;

namespace LearningManagementSystem.Services.Util
{
    public class ContactUtil
    {
        public static List<ContactDetail> dtoToContact(List<ContactDetailsDto> dtos, Guid PrimaryInfoId)
        {
            return dtos.Select(dto => new ContactDetail
            {
                ContactNo = dto.ContactNo,
                ContactType = dto.ContactType,
                PrimaryInfoId = PrimaryInfoId
            }).ToList();
        }
    }
}
