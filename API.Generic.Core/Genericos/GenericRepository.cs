using API.Core.Business.DBContext;
using Microsoft.Extensions.Logging;
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
        protected readonly ILogger _logger;

        public GenericRepository(AppDbContext db, ILogger logger)
        {
            _db = db;
            _logger = logger;

        }

        public void Delete(int? id)
        {
            _logger.LogWarning("se fija si existe el campo y lo borra");
            var entity = GetById(id);

            if (entity == null)
            {
                _logger.LogError("DELETE ERROR");
                throw new Exception("No se encontro objeto");//en caso de que no exista
            }
            else
            {
                _logger.LogInformation("ENTIDAD BORRADA");
                _db.Set<T>().Remove(entity);//en case de que exista, lo borra.
            }

        }

        public IEnumerable<T> GetAll()
        {
            _logger.LogInformation("llama el dato solicitado");
            return _db.Set<T>().ToList();
        }

        public T GetById(int? id)
        {
            _logger.LogInformation("Consulta el dato llamado : {id}", DateTimeOffset.Now);
            var aux = _db.Set<T>().Find(id);
            return aux;
        }

        public void Insert(T entity)
        {
            _logger.LogInformation("agrega un campo nuevo");
            _db.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _logger.LogInformation("modifica campo exisente");
            _db.Set<T>().Update(entity);
        }
    }
}
