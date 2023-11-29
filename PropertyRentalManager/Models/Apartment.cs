using System;
using System.Collections.Generic;

namespace PropertyRentalManager.Models
{
    public partial class Apartment
    {
        public int ApartmentId { get; set; }
        public int? BuildingId { get; set; }
        public int? StatusId { get; set; }
        public int? UnitNumber { get; set; }
        public double? Area { get; set; }
        public int? NumberOfRooms { get; set; }
        public double? Rent { get; set; }

        public virtual Building? Building { get; set; }
        public virtual Status? Status { get; set; }
    }
}
