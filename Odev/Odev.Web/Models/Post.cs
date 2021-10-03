using System;
using System.Collections.Generic;

#nullable disable

namespace Odev.Web.Models
{
    public partial class Post
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Baslik { get; set; }
        public string Aciklama { get; set; }
        public string Zaman { get; set; }
        public int? KategoriId { get; set; }

        public virtual Category Kategori { get; set; }
    }
}
