using LMS.Application.DAO;
using LMS.Application.Models.Dto;
using LMS.Application.Models.Entities;
using LMS.Application.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LMS.Application.Services.Implementations
{
    public class EducationRepository :IEducationRepository
    {
        private readonly AppDbContext _appDbContext;

        public EducationRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task addEducationDetails(EducationDetailsListDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }
            var primaryInfo = await _appDbContext.PrimaryInfos
                .Include(x => x.EducationDetails)
                .FirstOrDefaultAsync(p => p.Employee_Id == dto.Employee_Id);
            if (primaryInfo == null) 
            {
                throw new ArgumentException("PrimaryInfo with the given EmployeeId does not exist.");
            }
            if (primaryInfo.EducationDetails.Any())
            {
                _appDbContext.EducationDetails.RemoveRange(primaryInfo.EducationDetails);
                await _appDbContext.SaveChangesAsync();
            }
            try
            {
                var newEducationDetails = dto.EducationDetailsList.Select(e => new EducationDetail
                {
                    EducationType = e.EducationType,
                    Percentage = e.Percentage,
                    InstituteName = e.InstituteName,
                    Specialization = e.Specialization,
                    YearOfPassing = e.YearOfPassing,
                    UniversityName = e.UniversityName,
                    PrimaryInfoId = primaryInfo.PrimaryInfoId,
                }).ToList();

                primaryInfo.EducationDetails = newEducationDetails;
                _appDbContext.PrimaryInfos.Update(primaryInfo);
                await _appDbContext.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException ex)
            {
                Console.WriteLine($"Concurrency error:{ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving EducationDetails data:{ex.Message}");
                throw;
            }
        }
    }
}
