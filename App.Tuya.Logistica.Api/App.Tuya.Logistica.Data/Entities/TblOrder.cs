using System;
using System.Collections.Generic;

#nullable disable

namespace App.Tuya.Logistica.Data.Entities
{
    public partial class TblOrder
    {
        public TblOrder()
        {
            TblDetails = new HashSet<TblDetail>();
        }

        public Guid OrderId { get; set; } = Guid.NewGuid();
        public string OrderCode { get; set; }
        public Guid ClientInfoId { get; set; }
        public double TotalAmount { get; set; }
        public DateTime Date { get; set; }

        public virtual TblClientInfo ClientInfo { get; set; }
        public virtual ICollection<TblDetail> TblDetails { get; set; }
    }
}
