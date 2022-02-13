using System;
using System.Collections.Generic;

namespace BookRentalAppProject.Models
{
    public partial class RentDetails
    {
        public int RentId { get; set; }
        public int? MemberId { get; set; }
        public int? BookId { get; set; }
        public DateTime? BookTakenDate { get; set; }
        public DateTime? BookReturnedDate { get; set; }

        public virtual Books Book { get; set; }
        public virtual Members Member { get; set; }
    }
}
