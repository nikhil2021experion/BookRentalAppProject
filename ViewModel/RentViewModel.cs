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

        public string PublicationName { get; set; }
        public string GenreName { get; set; }
        public string AuthorName { get; set; }
        
        public int Price { get; set; }
        public int? RentPrice { get; set; }

        internal object FindListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
