using System;
using System.Collections.Generic;

#nullable disable

namespace App.Tuya.Logistica.Data.Entities
{
    public partial class TblDetail
    {
        public Guid DetailId { get; set; } = Guid.NewGuid();
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }

        public virtual TblOrder Order { get; set; }
        public virtual TblProduct Product { get; set; }
    }
}
