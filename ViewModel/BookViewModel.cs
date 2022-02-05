using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRentalAppProject.ViewModel
{
    public class BookViewModel
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int? PublicationId { get; set; }
        public int? GenreId { get; set; }
        public int? AuthorId { get; set; }
        public int Price { get; set; }
    }
}
