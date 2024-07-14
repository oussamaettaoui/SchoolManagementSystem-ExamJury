using SchoolManagementSystem.Application.Interfaces;
using SchoolManagementSystem.Application.IServices;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Services
{
    public class JuryMemberRoleService : IJuryMemberRoleService
    {
        #region Props
        private readonly IUnitOfWork _unitOfWork;
        #endregion
        #region Constructor
        public JuryMemberRoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion
        public async Task<List<JuryMemberRole>> GetJuryMemberRoleListAsync()
        {
            List<JuryMemberRole> rolesList = await _unitOfWork.JuryMemberRoleRepository.GetAllAsNoTracking();
            return rolesList;
        }
        public async Task<JuryMemberRole> GetJuryMemberRoleByIdAsync(Guid id)
        {
            JuryMemberRole role = await _unitOfWork.JuryMemberRoleRepository.GetAsNoTracking(x => x.Id.Equals(id));
            return role;
        }
        public async Task<Result> AddJuryMemberRoleAsync(JuryMemberRole juryMemberRole)
        {
            try
            {
                await _unitOfWork.JuryMemberRoleRepository.CreateAsync(juryMemberRole);
                await _unitOfWork.CommitAsync();
                return Result.Success;
            }
            catch (Exception ex)
            {
                return Result.Failure;
            }
        }
        public async Task<Result> EditJuryMemberRoleAsync(JuryMemberRole juryMemberRole)
        {

            try
            {
                await _unitOfWork.JuryMemberRoleRepository.UpdateAsync(juryMemberRole);
                await _unitOfWork.CommitAsync();
                return Result.Success;
            }
            catch (Exception ex)
            {
                return Result.Failure;
            }
        }
        public async Task<Result> DeleteJuryMemberRoleAsync(JuryMemberRole juryMemberRole)
        {
            try
            {
                await _unitOfWork.JuryMemberRoleRepository.RemoveAsync(juryMemberRole);
                await _unitOfWork.CommitAsync();
                return Result.Success;
            }
            catch (Exception ex)
            {
                return Result.Failure;
            }
        }
    }
}
