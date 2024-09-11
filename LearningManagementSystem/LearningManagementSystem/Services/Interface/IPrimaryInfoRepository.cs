using LearningManagementSystem.Models.Dto;

namespace LearningManagementSystem.Services.Interface
{
    public interface IPrimaryInfoRepository
    {
        public Task addPrimaryInfo(PrimaryInfoDto dto);
    }
}
