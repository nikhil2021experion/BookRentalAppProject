using System;
using System.Collections.Generic;

namespace BookRentalAppProject.Models
{
    public partial class Members
    {
        public Members()
        {
            RentDetails = new HashSet<RentDetails>();
        }

        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }

        public virtual ICollection<RentDetails> RentDetails { get; set; }
    }
}
