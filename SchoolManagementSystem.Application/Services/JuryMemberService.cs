using AutoMapper;
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
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        #endregion
        #region Constructor
        public JuryMemberService(IUnitOfWork uow, IHttpContextAccessor httpContextAccessor, IMapper mapper, IFileService fileService)
        {
            _uow = uow;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _fileService = fileService;
        }
        #endregion
        #region Methods
        // to retrieve JuryMember list
        public async Task<List<JuryMember>> GetJuryMemberListAsync()
        {
            List<JuryMember> juryMembers = await _uow.JuryMemberRepository.GetAllAsNoTracking();
            return juryMembers;
        }
        // to retrieve a specific JuryMember by id
        public async Task<JuryMember> GetJuryMemberByIdAsync(Guid id)
        {
            JuryMember jury = await _uow.JuryMemberRepository.GetAsNoTracking(x => x.Id.Equals(id));
            return jury;
        }
        // to add a new JuryMember
        public async Task<string> AddJuryMemberAsync(JuryMember juryMember,IFormFile ImgFile)
        {
            try
            {
                HttpRequest context = _httpContextAccessor.HttpContext.Request;
                string baseurl = context.Scheme + "://" + context.Host;
                string juryImg = await _fileService.UploadFile(ImgFile);
                juryMember.Id = Guid.NewGuid();
                juryMember.ProfileImg = baseurl + juryImg;
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
                if (!string.IsNullOrEmpty(juryMember.ProfileImg))
                {
                    var oldImgPath = juryMember.ProfileImg.Replace($"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}", "");
                    _fileService.DeleteFile(oldImgPath);
                }
                HttpRequest context = _httpContextAccessor.HttpContext.Request;
                string baseurl = context.Scheme + "://" + context.Host;
                string juryImg = await _fileService.UploadFile(ImgFile);
                juryMember.ProfileImg = baseurl + juryImg;
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
                var oldImgPath = juryMember.ProfileImg.Replace($"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}", "");
                _fileService.DeleteFile(oldImgPath);
            }
            await _uow.JuryMemberRepository.RemoveAsync(juryMember);
            await _uow.CommitAsync();
            return "Success";
        }
        #endregion
    }
}
