using System;
using System.Collections.Generic;

namespace PropertyRentalManager.Models
{
    public partial class PropertyManager
    {
        public PropertyManager()
        {
            Appointments = new HashSet<Appointment>();
            Messages = new HashSet<Message>();
            Reports = new HashSet<Report>();
        }

        public int ManagerId { get; set; }
        public int? UserId { get; set; }
        public int? BuildingId { get; set; }

        public virtual Building? Building { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
