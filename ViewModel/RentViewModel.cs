using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRentalAppProject.ViewModel
{
    public class RentViewModel
    {

        public int? BookId { get; set; }
        public string BookName { get; set; }

        public int? MemberId { get; set; }

        public string MemberName { get; set; }

        public string PublicationName { get; set; }
        public string GenreName { get; set; }
        public string AuthorName { get; set; }

        public DateTime? BookTakenDate { get; set; }
        public DateTime? BookReturnedDate { get; set; }

        public int Price { get; set; }
        public double? RentPrice { get; set; }

        internal object FindListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
