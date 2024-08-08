using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using SchoolManagementSystem.Application.Interfaces;
using SchoolManagementSystem.Application.IServices;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Services
{
    public class JuryMemberService : IJuryMemberService
    {
        #region Props
        private readonly IUnitOfWork _uow;
        private readonly IBlobService _blobService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        #endregion
        #region Constructor
        public JuryMemberService(IUnitOfWork uow, IBlobService blobService, IHttpContextAccessor httpContextAccessor)
        {
            _uow = uow;
            _blobService = blobService;
            _httpContextAccessor = httpContextAccessor;
        }
        #endregion
        #region Methods
        // to retrieve JuryMember list
        public async Task<List<JuryMember>> GetJuryMemberListAsync()
        {
            List<JuryMember> juryMembers = await _uow.JuryMemberRepository.GetJuryMembersWithRoleAsync();
            return juryMembers;
        }
        // to retrieve a specific JuryMember by id
        public async Task<JuryMember> GetJuryMemberByIdAsync(Guid id)
        {
            JuryMember jury = await _uow.JuryMemberRepository.GetJuryMemberWithRoleAsync(x => x.Id.Equals(id));
            return jury;
        }
        // to add a new JuryMember
        public async Task<string> AddJuryMemberAsync(JuryMember juryMember,IFormFile ImgFile)
        {
            try
            {
                juryMember.Id = Guid.NewGuid();
                ClaimsPrincipal? user = _httpContextAccessor.HttpContext?.User;
                string? userRole = user?.FindFirst(ClaimTypes.Role)?.Value;
                Status status = userRole switch { 
                    "director" => Status.Valid,
                    "assistant" => Status.InProgress,
                    _ => Status.Invalid
                };
                juryMember.Status = status;
                if (ImgFile is not null){
                    string imgUrl = await _blobService.UploadAsync(juryMember.Id, ImgFile);
                    juryMember.ProfileImg = imgUrl;
                }
                else
                {
                    juryMember.ProfileImg = "string";
                }
                await _uow.JuryMemberRepository.CreateAsync(juryMember);
                await _uow.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        // to edit a specific JuryMember
        public async Task<string> EditJuryMemberAsync(JuryMember juryMember, IFormFile ImgFile)
        {
            try
            {
                if (ImgFile is not null && !string.IsNullOrEmpty(juryMember.ProfileImg))
                {
                    _blobService.DeleteAsync(juryMember.Id.ToString());
                    string imgUrl = await _blobService.UploadAsync(juryMember.Id, ImgFile);
                    juryMember.ProfileImg = imgUrl;
                }
                juryMember.UpdatedAt = DateTime.UtcNow;
                await _uow.JuryMemberRepository.UpdateAsync(juryMember);
                await _uow.CommitAsync();
                return "Success";
            }
            catch(Exception ex)
            {
                throw new Exception("Error");
            }
        }
        // to delete a specific JuryMember
        public async Task<string> DeleteJuryMemberAsync(JuryMember juryMember)
        {
            if (!string.IsNullOrEmpty(juryMember.ProfileImg))
            {
                _blobService.DeleteAsync(juryMember.Id.ToString());
            }
            await _uow.JuryMemberRepository.RemoveAsync(juryMember);
            await _uow.CommitAsync();
            return "Success";
        }
        #endregion
    }
}
