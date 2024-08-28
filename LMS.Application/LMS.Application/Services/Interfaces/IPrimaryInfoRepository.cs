using LMS.Application.Models.Dto;
using LMS.Application.Models.Entities;

namespace LMS.Application.Services.Interfaces
{
    public interface IPrimaryInfoRepository
    {
        public Task addPrimaryInfo(PrimaryInfoDto dto);
        Task Update(PrimaryInfoDto dto);
    }
}
