using System;
using System.Collections.Generic;

namespace PropertyRentalManager.Models
{
    public partial class Tenant
    {
        public Tenant()
        {
            Appointments = new HashSet<Appointment>();
            Messages = new HashSet<Message>();
        }

        public int TenantId { get; set; }
        public int? UserId { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
