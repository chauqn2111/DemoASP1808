using System;
using System.Collections.Generic;

namespace AutomobileLibrary.DataAccess
{
    public partial class Catygorye
    {
        public Catygorye()
        {
            Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
