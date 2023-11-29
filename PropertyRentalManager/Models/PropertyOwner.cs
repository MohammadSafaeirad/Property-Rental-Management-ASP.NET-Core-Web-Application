using System;
using System.Collections.Generic;

namespace PropertyRentalManager.Models
{
    public partial class PropertyOwner
    {
        public PropertyOwner()
        {
            Reports = new HashSet<Report>();
        }

        public int OwnerId { get; set; }
        public int? UserId { get; set; }
        public int? BuildingId { get; set; }

        public virtual Building? Building { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
