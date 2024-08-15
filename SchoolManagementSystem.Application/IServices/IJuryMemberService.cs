using Microsoft.AspNetCore.Http;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.IServices
{
    public interface IJuryMemberService
    {
        Task<List<JuryMember>> GetJuryMemberListAsync();
        Task<JuryMember> GetJuryMemberByIdAsync(Guid id);
        Task<Result> AddJuryMemberAsync(JuryMember juryMember, IFormFile juryImg);
        Task<Result> EditJuryMemberAsync(JuryMember juryMember, IFormFile ImgFile);
        Task<Result> DeleteJuryMemberAsync(JuryMember juryMember);
        Task<Result> ValidateJuryMemberAsync(JuryMember juryMamber);

    }
}
