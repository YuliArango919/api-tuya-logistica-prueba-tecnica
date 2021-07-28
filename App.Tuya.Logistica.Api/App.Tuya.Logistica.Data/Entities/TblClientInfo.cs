using System;
using System.Collections.Generic;

#nullable disable

namespace App.Tuya.Logistica.Data.Entities
{
    public partial class TblClientInfo
    {
        public TblClientInfo()
        {
            TblOrders = new HashSet<TblOrder>();
        }

        public Guid ClientInfoId { get; set; } = Guid.NewGuid();
        public string DocumentNumber { get; set; }
        public string ClientName { get; set; }
        public string Adress { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<TblOrder> TblOrders { get; set; }
    }
}
