using AutoMapper;
using MediatR;
using SchoolManagementSystem.Application.Features.DayOrderFeature.Command.Commands;
using SchoolManagementSystem.Application.UnitOfServices.Abstractions;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Features.DayOrderFeature.Command.Handlers
{
    public class DeleteDayOrderCommandHanlder : IRequestHandler<DeleteDayOrderCommand, Result>
    {
        private readonly IUnitOfService _unitOfService;
        private readonly IMapper _mapper;
        public DeleteDayOrderCommandHanlder(IUnitOfService unitOfService, IMapper mapper)
        {
            _unitOfService = unitOfService;
            _mapper = mapper;
        }
        public async Task<Result> Handle(DeleteDayOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                DayOrder dayOrder = await _unitOfService.DayOrderService.GetDayOrderByIdAsync(request.DayOrderId);
                Result result = await _unitOfService.DayOrderService.DeleteDayOrderAsync(dayOrder);
                if (result == Result.Success)
                {
                    return Result.Success;
                }
                return Result.Failure;
            }
            catch (Exception ex)
            {
                throw new Exception("Faild In Add handler" + ex.ToString());
            }
        }
    }
}


// try
//{
  //  JuryMember juryMember = await _uos.JuryMemberService.GetJuryMemberByIdAsync(request.JuryMemberId);
    //string result = await _uos.JuryMemberService.DeleteJuryMemberAsync(juryMember);
    //if (result == "Success")
 //   {
   //     return "Jury Member Deleted Successfully";
    //}
  //  return "Error During Deleting";
//}
  //          catch (Exception ex)
    //        {
      //          throw new Exception("Error" + ex.ToString());
        //    }
