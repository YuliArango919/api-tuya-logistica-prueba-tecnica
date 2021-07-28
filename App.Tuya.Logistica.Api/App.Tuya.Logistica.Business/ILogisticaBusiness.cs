using App.Tuya.Logistica.Dtos.Logistica;
using System.Threading.Tasks;

namespace App.Tuya.Logistica.Business
{
    public interface ILogisticaBusiness
    {
        Task<PedidoTotalDto> CrearPedidoAsync(PedidoTotalDto pedidoEnviado);
    }
}
