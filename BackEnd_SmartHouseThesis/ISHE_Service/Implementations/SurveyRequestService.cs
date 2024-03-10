using AutoMapper;
using AutoMapper.QueryableExtensions;
using ISHE_Data;
using ISHE_Data.Entities;
using ISHE_Data.Models.Requests.Filters;
using ISHE_Data.Models.Requests.Get;
using ISHE_Data.Models.Requests.Post;
using ISHE_Data.Models.Requests.Put;
using ISHE_Data.Models.Views;
using ISHE_Data.Repositories.Interfaces;
using ISHE_Service.Interfaces;
using ISHE_Utility.Enum;
using ISHE_Utility.Exceptions;
using ISHE_Utility.Helpers.FormatDate;
using Microsoft.EntityFrameworkCore;

namespace ISHE_Service.Implementations
{
    public class SurveyRequestService : BaseService, ISurveyRequestService
    {
        private readonly ISurveyRequestRepository _surveyRequestRepository;
        private readonly IStaffAccountRepository _staffAccountRepository;
        public SurveyRequestService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            _surveyRequestRepository = unitOfWork.SurveyRequest;
            _staffAccountRepository = unitOfWork.StaffAccount;
        }

        public async Task<ListViewModel<SurveyRequestViewModel>> GetSurveyRequests(SurveyRequestFilterModel filter, PaginationRequestModel pagination)
        {
            var query = _surveyRequestRepository.GetAll();

            if (filter.CustomerId.HasValue)
            {
                query = query.Where(sv => sv.CustomerId.Equals(filter.CustomerId.Value));
            }

            if (filter.StaffId.HasValue)
            {
                query = query.Where(sv => sv.StaffId.Equals(filter.StaffId.Value));
            }

            if (filter.SurveyDate.HasValue)
            {
                query = query.Where(sv => sv.SurveyDate.Date.Equals(filter.SurveyDate.Value.Date));
            }

            if (!string.IsNullOrEmpty(filter.Status.ToString()))
            {
                query = query.Where(sv => sv.Status.Equals(filter.Status.ToString()));
            }

            var totalRow = await query.AsNoTracking().CountAsync();
            var paginatedQuery = query
                .OrderByDescending(sv => sv.CreateAt)
                .Skip(pagination.PageNumber * pagination.PageSize)
                .Take(pagination.PageSize);

            var surveyRequests = await paginatedQuery
                .ProjectTo<SurveyRequestViewModel>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync();
            return new ListViewModel<SurveyRequestViewModel>
            {
                Pagination = new PaginationViewModel
                {
                    PageNumber = pagination.PageNumber,
                    PageSize = pagination.PageSize,
                    TotalRow = totalRow
                },
                Data = surveyRequests
            };
        }

        public async Task<SurveyRequestViewModel> GetSurveyRequest(Guid id)
        {
            return await _surveyRequestRepository.GetMany(sv => sv.Id.Equals(id))
                .ProjectTo<SurveyRequestViewModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync() ?? throw new NotFoundException("Không tìm thấy survey request");
        }

        public async Task<SurveyRequestViewModel> CreateSurveyRequest(CreateSurveyRequestModel model)
        {
            var surveyDate = FormatDate.CheckFormatDate(model.SurveyDate);
            await CheckCustomerRequest(model.CustomerId, surveyDate);

            var request = new SurveyRequest
            {
                Id = Guid.NewGuid(),
                CustomerId = model.CustomerId,
                SurveyDate = surveyDate,
                Description = model.Description,
                Status = SurveyRequestStatus.Pending.ToString()
            };

            _surveyRequestRepository.Add(request);

            //Send noti ?

            var result = await _unitOfWork.SaveChanges();
            return result > 0 ? await GetSurveyRequest(request.Id) : null!;
        }

        public async Task<SurveyRequestViewModel> UpdateSurveyRequest(Guid id, UpdateSurveyRequestModel model)
        {
            var request = await _surveyRequestRepository.GetMany(sv => sv.Id.Equals(id))
                                        .FirstOrDefaultAsync() ?? throw new NotFoundException("Không tìm thầy survey request");

            if (!string.IsNullOrEmpty(model.SurveyDate))
            {
                var surveyDate = FormatDate.CheckFormatDate(model.SurveyDate);
                if (!request.SurveyDate.Date.Equals(surveyDate.Date))
                {
                    await CheckCustomerRequest(request.CustomerId, surveyDate);
                    request.SurveyDate = surveyDate;
                }
            }
            
            request.Description = model.Description ?? request.Description;
            request.Status = model.Status ?? request.Status;

            if (model.StaffId.HasValue)
            {
                await CheckStaffIsAvaiableForSurvey(model.StaffId.Value, request.SurveyDate.Date);
                request.StaffId = model.StaffId.Value;
                request.Status = SurveyRequestStatus.InProgress.ToString();
            }

            _surveyRequestRepository.Update(request);
            var result = await _unitOfWork.SaveChanges();
            return result > 0 ? await GetSurveyRequest(id) : null!;
        }

        //PRIVATE METHOD
        private async Task CheckCustomerRequest(Guid customerId, DateTime requestDate)
        {
            var existingRequest = await _surveyRequestRepository.GetMany(request => request.CustomerId.Equals(customerId)
                                                                && request.SurveyDate.Date.Equals(requestDate.Date))
                                                        .Include(request => request.Customer)
                                                        .FirstOrDefaultAsync();
            if (existingRequest != null)
            {
                throw new BadRequestException($"Customer {existingRequest.Customer.FullName} đã có lịch hẹn survey cho ngày {requestDate.ToString("dd-MM-yyyy")}");
            }
        }

        private async Task CheckStaffIsAvaiableForSurvey(Guid staffId, DateTime surveyDate)
        {
            //var staffAccount = await _staffRepository.GetMany(staff => staff.AccountId.Equals(staffId)
            //                 && staff.IsLead
            //                 && (staff.Contracts == null || !staff.Contracts.Any(contract =>
            //                    contract.StartPlanDate.Date <= surveyDate.Date && contract.EndPlanDate.Date >= surveyDate.Date))
            //                 && staff.Surveys.Count(sv => sv.SurveyRequest.SurveyDate.Date == surveyDate.Date) < 3
            //                 ).FirstOrDefaultAsync() ?? throw new BadRequestException($"Staff đã chọn không phù hợp để tiến hành khảo sát vào ngày {surveyDate.ToString("dd-MM-yyyy")}");

            var staffAccount = await _staffAccountRepository.GetMany(staff => staff.AccountId.Equals(staffId))
                .Include(sv => sv.Contracts)
                .Include(sv => sv.SurveyRequests)
                .FirstOrDefaultAsync() ?? throw new BadRequestException($"Không tìm thấy nhân viên với ID {staffId}");

            if (!staffAccount.IsLead ||
                (staffAccount.Contracts != null && staffAccount.Contracts.Any(contract =>
                    contract.StartPlanDate.Date <= surveyDate.Date && contract.EndPlanDate.Date >= surveyDate.Date)) ||
                staffAccount.SurveyRequests.Count(sv => sv.SurveyDate.Date == surveyDate.Date) >= 3)
            {
                throw new BadRequestException($"Nhân viên {staffAccount.FullName} không phù hợp để tham gia khảo sát vào ngày {surveyDate.ToString("dd-MM-yyyy")}");
            }
        }
    }
}
