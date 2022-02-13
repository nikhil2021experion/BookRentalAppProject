using System;
using System.Collections.Generic;

namespace BookRentalAppProject.Models
{
    public partial class Role
    {
        public Role()
        {
            Members = new HashSet<Members>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Members> Members { get; set; }
    }
}
