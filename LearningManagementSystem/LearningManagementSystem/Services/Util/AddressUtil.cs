using LearningManagementSystem.Models.Dto;
using LearningManagementSystem.Models.Entity;

namespace LearningManagementSystem.Services.Util
{
    public class AddressUtil
    {
        public static List<AddressDetail> dtoToAddressEntities(List<AddressDetailsDto> dtos, Guid PrimaryInfoId)
        {
            return dtos.Select(dto => new AddressDetail
            {
                AddressType = dto.AddressType,
                City = dto.City,
                DoorNo = dto.DoorNo,
                Street = dto.Street,    
                LandMark = dto.LandMark,
                Locality = dto.Locality,
                State = dto.State,  
                PinCode = dto.PinCode,
                PrimaryInfoId = PrimaryInfoId
            }).ToList();
        }
    }
}
