using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.IServices
{
    public interface IJuryService
    {
        Task<List<Jury>> GetJuryListAsync();
        Task<Jury> GetJuryByIdAsync(Guid id);
        Task<Result> AddJuryAsync(Jury jury);
        Task<Result> UpdateJuryAsync(Jury jury);
        Task<Result> DeleteJuryAsync(Jury jury);
    }
}
