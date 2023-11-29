using System;
using System.Collections.Generic;

namespace PropertyRentalManager.Models
{
    public partial class Appointment
    {
        public int AppointmentId { get; set; }
        public int? TenantId { get; set; }
        public int? ManagerId { get; set; }
        public DateTime? AppointmentDate { get; set; }

        public virtual PropertyManager? Manager { get; set; }
        public virtual Tenant? Tenant { get; set; }
    }
}
