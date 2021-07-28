using Dapper.Contrib.Extensions;

namespace App.Tuya.Logistica.Data.Model
{
    [Table("tblOrder")]
    public class PedidoModel
    {
        [ExplicitKey]
        public decimal Id { get; set; }
        public string OrderCode { get; set; }
        public string DocumentNumber { get; set; }
        public string ProductCode { get; set; }
        public double TotalAmount { get; set; }
        public string Date { get; set; }
    }
}
