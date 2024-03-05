using System;
using System.Collections.Generic;

namespace ISHE_Data.Entities
{
    public partial class SurveyRequest
    {
        public SurveyRequest()
        {
            Surveys = new HashSet<Survey>();
        }

        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime SurveyDate { get; set; }
        public string Description { get; set; } = null!;
        public string Status { get; set; } = null!;
        public DateTime CreateAt { get; set; }

        public virtual CustomerAccount Customer { get; set; } = null!;
        public virtual ICollection<Survey> Surveys { get; set; }
    }
}
