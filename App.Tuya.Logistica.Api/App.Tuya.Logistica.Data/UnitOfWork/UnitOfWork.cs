using App.Tuya.Logistica.Data.Entities;
using App.Tuya.Logistica.Data.Repository;
using System;
using System.Threading.Tasks;

namespace App.Tuya.Logistica.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TUYAPAGOSContext _contexto;
        private GenericRepository<TblClientInfo> clientInfo;
        private GenericRepository<TblProduct> product;
        private GenericRepository<TblOrder> order;
        private GenericRepository<TblDetail> detail;

        public UnitOfWork(TUYAPAGOSContext contexto)
        {
            _contexto = contexto;
        }

        public UnitOfWork()
        {
            _contexto = new TUYAPAGOSContext();
        }

        public GenericRepository<TblClientInfo> ClienteRepository
        {
            get
            {
                if (clientInfo == null)
                {
                    clientInfo = new GenericRepository<TblClientInfo>(_contexto);
                }
                return clientInfo;
            }
        }

        public GenericRepository<TblProduct> ProductoRepository
        {
            get
            {
                if (product == null)
                {
                    product = new GenericRepository<TblProduct>(_contexto);
                }
                return product;
            }
        }

        public GenericRepository<TblOrder> PedidoRepository
        {
            get
            {
                if (order == null)
                {
                    order = new GenericRepository<TblOrder>(_contexto);
                }
                return order;
            }
        }

        public GenericRepository<TblDetail> DetalleRepository
        {
            get
            {
                if (detail == null)
                {
                    detail = new GenericRepository<TblDetail>(_contexto);
                }
                return detail;
            }
        }

        public void Save()
        {
            _contexto.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _contexto.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                _contexto.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
