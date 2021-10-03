using System;
using System.Collections.Generic;

#nullable disable

namespace Odev.API.Models
{
    public partial class Category
    {
        public Category()
        {
            Posts = new HashSet<Post>();
        }

        public int Id { get; set; }
        public string Adi { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
