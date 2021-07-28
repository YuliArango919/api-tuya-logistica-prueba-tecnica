using System;
using System.Collections.Generic;

#nullable disable

namespace App.Tuya.Logistica.Data.Entities
{
    public partial class TblProduct
    {
        public TblProduct()
        {
            TblDetails = new HashSet<TblDetail>();
        }

        public Guid ProductId { get; set; } = Guid.NewGuid();
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }

        public virtual ICollection<TblDetail> TblDetails { get; set; }
    }
}
