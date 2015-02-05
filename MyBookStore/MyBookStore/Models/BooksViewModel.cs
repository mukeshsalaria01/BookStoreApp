using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBookStore.Models
{
    public class BooksViewModel
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string BookId { get; set; }
        public string Titlte { get; set; }
        public string Descripton { get; set; }
        public string Author { get; set; }
        public decimal? Price { get; set; }
        public string ImageUrl { get; set; }
        public System.DateTime? ReleaseDate { get; set; }
        public string Publisher { get; set; }
        public System.DateTime? ExpectedDeliveryDate { get; set; }
        public bool? Checked { get; set; }
        public System.DateTime? DateCreated { get; set; }
        public string ModifyBy { get; set; }
        public System.DateTime? DateModified { get; set; }
        public bool? IsDeleted { get; set; }
    }
}