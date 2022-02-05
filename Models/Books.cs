using System;
using System.Collections.Generic;

namespace BookRentalAppProject.Models
{
    public partial class Books
    {
        public Books()
        {
            RentDetails = new HashSet<RentDetails>();
        }

        public int BookId { get; set; }
        public string BookName { get; set; }
        public int? PublicationId { get; set; }
        public int? GenreId { get; set; }
        public int? AuthorId { get; set; }
        public int Price { get; set; }

        public virtual Authors Author { get; set; }
        public virtual GenreDetails Genre { get; set; }
        public virtual PublicationDetails Publication { get; set; }
        public virtual ICollection<RentDetails> RentDetails { get; set; }
    }
}
