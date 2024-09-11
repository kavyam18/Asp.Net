using LearningManagementSystem.Models.Dto;

namespace LearningManagementSystem.Services.Interface
{
    public interface ISecondaryInfoRepository
    {
        Task addSecondaryInfo(SecondaryInfoDto dto);
    }
}
