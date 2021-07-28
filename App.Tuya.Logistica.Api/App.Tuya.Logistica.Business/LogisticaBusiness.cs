using App.Tuya.Logistica.Data.Entities;
using App.Tuya.Logistica.Data.UnitOfWork;
using App.Tuya.Logistica.Dtos.Logistica;
using System;
using System.Threading.Tasks;
using static App.Tuya.Logistica.Common.Resources.GenericValuesResource;

namespace App.Tuya.Logistica.Business
{
    public class LogisticaBusiness : ILogisticaBusiness
    {
        private readonly IUnitOfWork _logisticaRepository;

        public LogisticaBusiness(IUnitOfWork logisticaRepository)
        {
            _logisticaRepository = logisticaRepository ?? throw new ArgumentNullException(nameof(logisticaRepository));
        }

        public async Task<PedidoTotalDto> CrearPedidoAsync(PedidoTotalDto pedidoEnviado)
        {
            if (pedidoEnviado != null)
            {
                TblOrder order = new TblOrder();

                order.OrderCode = pedidoEnviado.Pedido.CodigoPedido;
                order.Date = DateTime.Now;
                order.TotalAmount = pedidoEnviado.TotalSuma;
                GuardarClientInfo(order, pedidoEnviado);
                _logisticaRepository.PedidoRepository.Insert(order);
                GuardarProducto(order, pedidoEnviado);
            }

            return await Task.FromResult(pedidoEnviado);
        }

        public void GuardarProducto(TblOrder order, PedidoTotalDto pedidoEnviado)
        {
            foreach (var item in pedidoEnviado.Pedido.Products)
            {
                TblDetail detail = new TblDetail();
                TblProduct product = new TblProduct();
                detail.ProductId = product.ProductId;
                detail.OrderId = order.OrderId;
                product.ProductCode = item.Codigo;
                product.ProductName = item.Nombre;
                product.Price = item.Precio;
                product.Quantity = item.Cantidad;
                product.Description = item.Descripcion;

                _logisticaRepository.ProductoRepository.Insert(product);
                _logisticaRepository.DetalleRepository.Insert(detail);
            }
        }

        public void GuardarClientInfo(TblOrder order, PedidoTotalDto pedidoEnviado)
        {
            TblClientInfo client = new TblClientInfo();
            order.ClientInfoId = client.ClientInfoId;
            client.DocumentNumber = pedidoEnviado.Pedido.DatosCliente.DocumentoIdentidad;
            client.ClientName = pedidoEnviado.Pedido.DatosCliente.Nombre;
            client.Adress = pedidoEnviado.Pedido.DatosCliente.Direccion;
            client.Email = pedidoEnviado.Pedido.DatosCliente.Correo;
            client.Phone = pedidoEnviado.Pedido.DatosCliente.Telefono;
            client.PostalCode = pedidoEnviado.Pedido.DatosCliente.CodigoPostal;

            order.ClientInfo = client;
            _logisticaRepository.ClienteRepository.Insert(client);
        }
    }
}
