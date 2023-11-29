using System;
using System.Collections.Generic;

namespace PropertyRentalManager.Models
{
    public partial class Message
    {
        public int MessageId { get; set; }
        public int? ManagerId { get; set; }
        public int? TenantId { get; set; }
        public string? MessageBody { get; set; }
        public DateTime? DateSent { get; set; }
        public string? Sender { get; set; }

        public virtual PropertyManager? Manager { get; set; }
        public virtual Tenant? Tenant { get; set; }
    }
}
