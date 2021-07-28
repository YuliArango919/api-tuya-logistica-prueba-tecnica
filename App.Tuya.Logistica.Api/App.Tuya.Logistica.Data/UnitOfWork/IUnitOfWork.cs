using App.Tuya.Logistica.Data.Entities;
using App.Tuya.Logistica.Data.Repository;
using System;
using System.Threading.Tasks;

namespace App.Tuya.Logistica.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        GenericRepository<TblClientInfo> ClienteRepository { get; }
        GenericRepository<TblProduct> ProductoRepository { get; }
        GenericRepository<TblOrder> PedidoRepository { get; }
        GenericRepository<TblDetail> DetalleRepository { get; }
        void Save();
        Task SaveAsync();
    }
}
