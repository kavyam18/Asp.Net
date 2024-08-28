using LMS.Application.Models.Dto;

namespace LMS.Application.Services.Interfaces
{
    public interface ISecondaryInfoRepository
    {
        Task addSecondaryInfo(SecondaryInfoDto dto);
    }
}
