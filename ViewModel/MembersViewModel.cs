using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRentalAppProject.ViewModel
{
    public class MembersViewModel
    {
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }

        public string Password { get; set; }

        public int BookId { get; set; }
        public string BookName { get; set; }       
        public int Price { get; set; }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public DateTime? BookTakenDate { get; set; }
        public DateTime? BookReturnedDate { get; set; }
        public double? RentPrice { get; set; }

        public double? FineAmount { get; set; }
    }
}
