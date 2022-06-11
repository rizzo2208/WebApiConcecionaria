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

        public void Delete(int? id)
        {
            
            var entity = GetById(id);//se fija si existe el campo y lo borra

            if (entity == null)
            {

                logger.Info("REMOVE EXCEPTION CATCH => OK ");
                throw new Exception("No se encontro objeto");//en caso de que no exista
            }
            else
            {
                logger.Info("REMOVE => OK ");
                _db.Set<T>().Remove(entity);//en case de que exista, lo borra.
            }

        }

        public IEnumerable<T> GetAll()
        {
            logger.Info(@"GETALL METHOD => OK ");
            return _db.Set<T>().ToList();//llama el dato solicitado
        }

        public T GetById(int? id)
        {
            logger.Info("GETBYID METHOD => OK ");
            var aux = _db.Set<T>().Find(id);//Consulta el dato llamado
            return aux;
        }

        public void Insert(T entity)
        {
            logger.Info("INSERT METHOD => OK");
            _db.Set<T>().Add(entity);//agrega un campo nuevo
        }

        public void Update(T entity)
        {
            logger.Info("UPLOADING METHOD => OK ");
            _db.Set<T>().Update(entity);//modifica campo exisente
        }
    }
}
