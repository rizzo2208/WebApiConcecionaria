using API.Core.Business.DBContext;
using Microsoft.Extensions.Logging;
using Middleware.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Generic.Core.Genericos
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        protected readonly AppDbContext _db;
        protected readonly LoggerCustom logger;

        public GenericRepository(AppDbContext db, LoggerCustom logger)
        {
            _db = db;
            this.logger = logger;
            

        }

        # region Delete
        public void Delete(int? id)
        {
            
            var entity = GetById(id);//se fija si existe el campo y lo borra

            if (entity == null)
            {

                logger.Info("No Se Encontro Registro");
                throw new Exception("No se encontro objeto");//en caso de que no exista
            }
            else
            {
                logger.Info("REMOVIDO => OK ");
                _db.Set<T>().Remove(entity);//en case de que exista, lo borra.
            }
                
            

        }
        #endregion Delete


        #region GetById
        public IEnumerable<T> GetAll()
        {
            logger.Info(@"METODO GET => OK ");
            return _db.Set<T>().ToList();//llama el dato solicitado
        }
        
        public T GetById(int? id)
        {
            logger.Info("METODO GET ID => OK ");
            var aux = _db.Set<T>().Find(id);//Consulta el dato llamado
            return aux;
        }
        #endregion GetById

        #region Insert
        public void Insert(T entity)
        {
            logger.Info("METODO SET => OK");
            _db.Set<T>().Add(entity);//agrega un campo nuevo
        }
        #endregion Insert

        #region Update
        public void Update(T entity)
        {
            logger.Info("METODO UPDATE => OK ");
            _db.Set<T>().Update(entity);//modifica campo exisente
        }
        #endregion Update

    }
}
