using System;
using System.Collections.Generic;

namespace ISHE_Data.Entities
{
    public partial class Survey
    {
        public Guid Id { get; set; }
        public Guid SurveyRequestId { get; set; }
        public Guid? RecommendDevicePackageId { get; set; }
        public Guid StaffId { get; set; }
        public decimal? RoomArea { get; set; }
        public string Description { get; set; } = null!;
        public string Status { get; set; } = null!;
        public DateTime CreateAt { get; set; }

        public virtual DevicePackage? RecommendDevicePackage { get; set; }
        public virtual StaffAccount Staff { get; set; } = null!;
        public virtual SurveyRequest SurveyRequest { get; set; } = null!;
    }
}
