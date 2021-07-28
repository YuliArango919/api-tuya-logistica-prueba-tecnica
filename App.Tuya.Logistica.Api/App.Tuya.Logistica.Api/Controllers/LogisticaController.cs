using App.Tuya.Logistica.Business;
using App.Tuya.Logistica.Common.Utils;
using App.Tuya.Logistica.Dtos.Logistica;
using App.Tuya.Logistica.Dtos.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace App.Tuya.Logistica.Api.Controllers
{
    public class LogisticaController : BaseController
    {
        #region [Constructor]

        private readonly ILogisticaBusiness _logisticaBusiness;

        public LogisticaController(ILogisticaBusiness logisticaBusiness)
        {
            _logisticaBusiness = logisticaBusiness ?? throw new ArgumentNullException(nameof(logisticaBusiness));
        }

        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="createRequestDto"></param>
        /// <returns></returns>
        [HttpPost("RegistrarPedido")]
        [ProducesResponseType(typeof(HttpResponseDto<PedidoTotalDto>), 200)]
        public async Task<IActionResult> CrearPedido([FromBody] PedidoTotalDto pedido)
        {
            PedidoTotalDto result = await _logisticaBusiness.CrearPedidoAsync(pedido);
            return ServiceAnswer<PedidoTotalDto>.Response(HttpStatusCode.OK, "", result);
        }
    }
}
