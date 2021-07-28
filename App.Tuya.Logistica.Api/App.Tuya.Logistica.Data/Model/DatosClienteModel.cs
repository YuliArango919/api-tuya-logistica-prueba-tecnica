using Dapper.Contrib.Extensions;

namespace App.Tuya.Logistica.Data.Model
{
    [Table("tblClientInfo")]
    public class DatosClienteModel
    {
        [ExplicitKey]
        public decimal Id { get; set; }
        public string DocumentNumber { get; set; }
        public string ClientName { get; set; }
        public string Adress { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
