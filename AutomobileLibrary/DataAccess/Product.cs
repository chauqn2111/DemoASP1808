using System;
using System.Collections.Generic;

namespace AutomobileLibrary.DataAccess
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int CategoryId { get; set; }

        public virtual Catygorye Category { get; set; } = null!;
    }
}
