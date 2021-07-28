using Dapper.Contrib.Extensions;

namespace App.Tuya.Logistica.Data.Model
{
    [Table("tblProducts")]
    public class ProductosModel
    {
        [ExplicitKey]
        public decimal Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
    }
}
