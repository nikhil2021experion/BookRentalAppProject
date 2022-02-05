using System;
using System.Collections.Generic;

namespace BookRentalAppProject.Models
{
    public partial class PublicationDetails
    {
        public PublicationDetails()
        {
            Books = new HashSet<Books>();
        }

        public int PublicationId { get; set; }
        public string PublicationName { get; set; }

        public virtual ICollection<Books> Books { get; set; }
    }
}
