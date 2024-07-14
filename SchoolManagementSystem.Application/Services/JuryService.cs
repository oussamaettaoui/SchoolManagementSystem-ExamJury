using SchoolManagementSystem.Application.Interfaces;
using SchoolManagementSystem.Application.IServices;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Services
{
    public class JuryService : IJuryService
    {
        #region Props
        private readonly IUnitOfWork _unitOfWork;
        #endregion
        #region Constructor
        public JuryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion
        #region Methods
        public async Task<List<Jury>> GetJuryListAsync()
        {
            List<Jury> juries = await _unitOfWork.JuryRepository.GetAllAsNoTracking();
            return juries;
        }
        public async Task<Jury> GetJuryByIdAsync(Guid id)
        {
            Jury jury = await _unitOfWork.JuryRepository.GetAsNoTracking(x => x.Id.Equals(id));
            return jury;
        }
        public async Task<Result> AddJuryAsync(Jury jury)
        {
            try
            {
                await _unitOfWork.JuryRepository.CreateAsync(jury);
                await _unitOfWork.CommitAsync();
                return Result.Success;
            }
            catch (Exception ex)
            {
                return Result.Failure;
            }
        }
        public async Task<Result> UpdateJuryAsync(Jury jury)
        {
            try
            {
                await _unitOfWork.JuryRepository.UpdateAsync(jury);
                await _unitOfWork.CommitAsync();
                return Result.Success;
            }
            catch (Exception ex)
            {
                return Result.Failure;
            }
        }
        public async Task<Result> DeleteJuryAsync(Jury jury)
        {
            try
            {
                await _unitOfWork.JuryRepository.RemoveAsync(jury);
                await _unitOfWork.CommitAsync();
                return Result.Success;
            }
            catch (Exception ex)
            {
                return Result.Failure;
            }
        }
        #endregion
    }
}
