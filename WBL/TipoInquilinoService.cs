using BD;
using Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WBL
{
    public interface ITipoInquilinoService
    {
        Task<DBEntity> Insert(TipoInquilinoEntity entity);
        Task<DBEntity> Update(TipoInquilinoEntity entity);
        Task<DBEntity> Delete(TipoInquilinoEntity entity);
        Task<IEnumerable<TipoInquilinoEntity>> Get();
        Task<TipoInquilinoEntity> GetById(TipoInquilinoEntity entity);
    }

    public class TipoInquilinoService : ITipoInquilinoService
    {
        private readonly IDataAccess sql;

        public TipoInquilinoService(IDataAccess sql)
        {
            this.sql = sql;
        }

        public async Task<IEnumerable<TipoInquilinoEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<TipoInquilinoEntity>("TipoInquilinoObtener");
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TipoInquilinoEntity> GetById(TipoInquilinoEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<TipoInquilinoEntity>("TipoInquilinoObtener", new { entity.Id_TipoInquilino });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DBEntity> Insert(TipoInquilinoEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("TipoInquilinoInsertar", new
                {
                    entity.Descripcion,
                    entity.Estado
                });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DBEntity> Update(TipoInquilinoEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("TipoInquilinoActualizar", new
                {
                    entity.Id_TipoInquilino,
                    entity.Descripcion,
                    entity.Estado
                });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DBEntity> Delete(TipoInquilinoEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("TipoInquilinoEliminar", new { entity.Id_TipoInquilino });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
