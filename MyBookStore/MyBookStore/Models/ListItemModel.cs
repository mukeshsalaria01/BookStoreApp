using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBookStore.Models
{
    public class ListItemModel
    {
        
        public bool? Checked { get; set; }
        public string ISBN { get; set; }
        public string ImageUrl { get; set; }
    }
}