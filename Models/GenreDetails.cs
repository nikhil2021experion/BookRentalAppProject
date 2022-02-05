using System;
using System.Collections.Generic;

namespace BookRentalAppProject.Models
{
    public partial class GenreDetails
    {
        public GenreDetails()
        {
            Books = new HashSet<Books>();
        }

        public int GenreId { get; set; }
        public string GenreName { get; set; }

        public virtual ICollection<Books> Books { get; set; }
    }
}
