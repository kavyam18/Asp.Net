using LMS.Application.DAO;
using LMS.Application.Models.Dto;
using LMS.Application.Services.Interfaces;
using LMS.Application.Services.Util;
using Microsoft.EntityFrameworkCore;

namespace LMS.Application.Services.Implementations
{
    public class ExperienceRepository : IExperienceRepository
    {
        private readonly IExperienceRepository _experienceRepository;
        private readonly AppDbContext _context;

        public ExperienceRepository(AppDbContext context)
        {
            _context = context;
        }
    

       public async Task addExperienceDetails(ExperienceDtoList dto)
            {
                if (dto == null)
                {
                    throw new ArgumentNullException(nameof(dto));
                }
                var primaryInfo = await _context.PrimaryInfos
                    .Include(p => p.ExperienceDetails)
                    .FirstOrDefaultAsync(p => p.Employee_Id == dto.Employee_Id);
                if (primaryInfo == null) 
                {
                    _context.Experiences.RemoveRange(primaryInfo.ExperienceDetails);
                    await _context.SaveChangesAsync();
                }
                var newExperience = ExperienceUtil.
            }
  
    }
}
