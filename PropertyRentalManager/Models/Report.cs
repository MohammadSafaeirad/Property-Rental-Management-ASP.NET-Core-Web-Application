using System;
using System.Collections.Generic;

namespace PropertyRentalManager.Models
{
    public partial class Report
    {
        public int ReportId { get; set; }
        public int? OwnerId { get; set; }
        public int? ManagerId { get; set; }
        public string? ReportBody { get; set; }
        public DateTime? DateSent { get; set; }

        public virtual PropertyManager? Manager { get; set; }
        public virtual PropertyOwner? Owner { get; set; }
    }
}
