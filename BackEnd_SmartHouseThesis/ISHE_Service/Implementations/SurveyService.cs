﻿using AutoMapper;
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
using Microsoft.EntityFrameworkCore;

namespace ISHE_Service.Implementations
{
    public class SurveyService : BaseService, ISurveyService
    {
        private readonly ISurveyRepository _surveyRepository;
        private readonly IStaffAccountRepository _staffRepository;
        private readonly ISurveyRequestRepository _surveyRequestRepository;
        public SurveyService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            _surveyRepository = unitOfWork.Survey;
            _staffRepository = unitOfWork.StaffAccount;
            _surveyRequestRepository = unitOfWork.SurveyRequest;
        }

        public async Task<ListViewModel<SurveyViewModel>> GetSurveys(SurveyFilterModel filter, PaginationRequestModel pagination)
        {
            var query = _surveyRepository.GetAll();


            if (filter.AppointmentDate.HasValue)
            {
                query = query.Where(sv => sv.AppointmentDate.Date.Equals(filter.AppointmentDate.Value.Date));
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

            var surveys = await paginatedQuery
                .ProjectTo<SurveyViewModel>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync();
            return new ListViewModel<SurveyViewModel>
            {
                Pagination = new PaginationViewModel
                {
                    PageNumber = pagination.PageNumber,
                    PageSize = pagination.PageSize,
                    TotalRow = totalRow
                },
                Data = surveys
            };
        }

        public async Task<SurveyViewModel> GetSurvey(Guid id)
        {
            return await _surveyRepository.GetMany(sv => sv.Id.Equals(id))
                .ProjectTo<SurveyViewModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync() ?? throw new NotFoundException("Không tìm thấy survey");
        }

        public async Task<SurveyViewModel> CreateSurvey(CreateSurveyModel model)
        {
            var surveyRequest = await _surveyRequestRepository.GetMany(sv => sv.Id.Equals(model.SurveyRequestId))
                .FirstOrDefaultAsync() ?? throw new NotFoundException("Không tìm thấy survey request");

            //await CheckStaffIsAvaiableForSurvey(model.StaffId, surveyRequest.SurveyDate);

            var survey = new Survey
            {
                Id = Guid.NewGuid(),
                SurveyRequestId = model.SurveyRequestId,
                RecommendDevicePackageId = model.RecommendDevicePackageId,
                RoomArea = model.RoomArea,
                Description = model.Description,
                AppointmentDate = model.AppointmentDate,
                Status = SurveyStatus.Pending.ToString(),
            };

            _surveyRepository.Add(survey);

            surveyRequest.Status = SurveyRequestStatus.Completed.ToString();
            _surveyRequestRepository.Update(surveyRequest);

            var result = await _unitOfWork.SaveChanges();
            return result > 0 ? await GetSurvey(survey.Id) : null!;
        }

        public async Task<SurveyViewModel> UpdateSurvey(Guid id, UpdateSurveyModel model)
        {
            var survey = await _surveyRepository.GetMany(sv => sv.Id.Equals(id))
                    .Include(sv => sv.SurveyRequest)
                    .FirstOrDefaultAsync() ?? throw new NotFoundException("Không tìm thấy survey");

            survey.RecommendDevicePackageId = model.RecommendDevicePackageId ?? survey.RecommendDevicePackageId;
            survey.AppointmentDate = model.AppointmentDate ?? survey.AppointmentDate;
            survey.RoomArea = model.RoomArea ?? survey.RoomArea;
            survey.Description = model.Description ?? survey.Description;
            survey.Status = model.Status ?? survey.Status;

            _surveyRepository.Update(survey);
            var result = await _unitOfWork.SaveChanges();
            return result > 0 ? await GetSurvey(id) : null!;
        }

        //PRIVATE METHOD

    }
}
