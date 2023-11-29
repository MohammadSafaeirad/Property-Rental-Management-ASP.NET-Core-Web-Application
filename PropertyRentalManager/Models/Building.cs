using System;
using System.Collections.Generic;

namespace PropertyRentalManager.Models
{
    public partial class Building
    {
        public Building()
        {
            Apartments = new HashSet<Apartment>();
            PropertyManagers = new HashSet<PropertyManager>();
            PropertyOwners = new HashSet<PropertyOwner>();
        }

        public int BuildingId { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }

        public virtual ICollection<Apartment> Apartments { get; set; }
        public virtual ICollection<PropertyManager> PropertyManagers { get; set; }
        public virtual ICollection<PropertyOwner> PropertyOwners { get; set; }
    }
}
