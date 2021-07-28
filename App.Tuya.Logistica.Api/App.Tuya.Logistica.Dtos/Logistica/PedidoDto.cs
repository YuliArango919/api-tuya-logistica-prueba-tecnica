using App.Tuya.Logistica.Dtos.Client;
using App.Tuya.Logistica.Dtos.Products;
using System.Collections.Generic;

namespace App.Tuya.Logistica.Dtos.Logistica
{
    public class PedidoDto
    {
        public string CodigoPedido { get; set; }
        public DatosClienteDto DatosCliente { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}
