using Microsoft.AspNetCore.Http;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.IServices
{
    public interface IJuryMemberService
    {
        Task<List<JuryMember>> GetJuryMemberListAsync();
        Task<JuryMember> GetJuryMemberByIdAsync(Guid id);
        Task<string> AddJuryMemberAsync(JuryMember juryMember, IFormFile juryImg,int role);
        Task<string> EditJuryMemberAsync(JuryMember juryMember, IFormFile ImgFile, int Role);
        Task<string> DeleteJuryMemberAsync(JuryMember juryMember);

    }
}
