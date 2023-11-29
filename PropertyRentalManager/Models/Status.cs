using System;
using System.Collections.Generic;

namespace PropertyRentalManager.Models
{
    public partial class Status
    {
        public Status()
        {
            Apartments = new HashSet<Apartment>();
        }

        public int StatusId { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Apartment> Apartments { get; set; }
    }
}
