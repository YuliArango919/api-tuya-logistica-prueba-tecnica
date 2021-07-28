using App.Tuya.Logistica.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace App.Tuya.Logistica.Data.Repository
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal TUYAPAGOSContext _contexto;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(TUYAPAGOSContext contexto)
        {
            _contexto = contexto;
            dbSet = _contexto.Set<TEntity>();
        }

        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
            _contexto.SaveChanges();
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            _contexto.Entry(entityToUpdate).State = EntityState.Modified;
            _contexto.SaveChanges();
        }

        public async Task UpdateAsync(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            _contexto.Entry(entityToUpdate).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
        }

        public async Task InsertAsync(TEntity entity)
        {
            if (entity != null)
            {
                await dbSet.AddAsync(entity);
                _contexto.SaveChanges();
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>,
               IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "", bool track = false)
        {

            IQueryable<TEntity> query = (!track) ? dbSet.AsNoTracking() : dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return (orderBy != null) ? await orderBy(query).ToListAsync().ConfigureAwait(false) : await query.ToListAsync().ConfigureAwait(false);
        }

        //    //    //public async Task<PreapprovedResponse> getPreApprovedInfo(string identificationNumber)
        //    //    //{
        //    //    //    PreapprovedResponse preaprobadosInf = new PreapprovedResponse();

        //    //    //    var preaprobadosInfo = _contexto.ClientePreaprobado.Join(_contexto.Solicitud,
        //    //    //                      cp => cp.NumeroIdentificacion,
        //    //    //                      s => s.NumeroIdentificacion,
        //    //    //                      (cp, s) => new { ClientePreaprobado = cp, solicitud = s })
        //    //    //                  .Where(cp_s => cp_s.solicitud.NumeroIdentificacion == identificationNumber
        //    //    //                  && cp_s.ClientePreaprobado.NumeroIdentificacion == identificationNumber)
        //    //    //                  .Select(cp_s => new PreapprovedResponse
        //    //    //                  {
        //    //    //                      IdentificationNumber = cp_s.solicitud.NumeroIdentificacion,
        //    //    //                      IsPreapproved = cp_s.solicitud.EstadoSolicitud == 1 ? true : false,
        //    //    //                      PreApprovedValue = cp_s.solicitud.ValorAprobado,
        //    //    //                      PreApprovedRequestedValue = cp_s.solicitud.ValorSolicitado,
        //    //    //                      Validity = cp_s.ClientePreaprobado.FechaVencimiento
        //    //    //                  }).FirstOrDefault();

        //    //    //    return preaprobadosInfo;
        //    //    //}
        //    //}
    }
}
