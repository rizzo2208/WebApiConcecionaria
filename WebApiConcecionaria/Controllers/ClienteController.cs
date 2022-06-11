using API.Core.Business.Entities;
using API.Uses.Cases.UOWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



namespace WebApiConcecionaria.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly IUnitOfWork _context;

        public ClienteController(IUnitOfWork context)
        {
            _context = context;
           
        }

        //GET
        //-----------------------------------------------------------
        /// <summary>
        /// Api para seleccionar todos los clientes de la base de datos.
        /// </summary>
        /// <param name="cliente">Estructura</param>
        /// <response code="200">Se creo correctamente</response>
        /// <response code="404">Cliente no encontrado</response>
        /// <response code="500">Oops! No se pudo buscar el Cliente</response>
        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> Get()
        {
           
            var entidad = _context.ClienteRepo.GetAll();//llama a todos los registros activos
            return Ok(entidad);
        }

        //POST
        //-----------------------------------------------------------
        /// <summary>
        /// cargo un regitro en a tabla clientes
        /// </summary>
        /// <param name="cliente">Estructura</param>
        /// <response code="200">Se creo correctamente</response>
        /// <response code="404">Cliente no encontrado</response>
        /// <response code="500">Oops! No se pudo buscar el Cliente</response>
        [HttpPost]
        public ActionResult Post([FromBody] Cliente cliente)
        {
            
            _context.ClienteRepo.Insert(cliente);//agrega un registro
            _context.Save();
            return Ok();
        }

        //PUT
        //-----------------------------------------------------------
        /// <summary>
        /// modifica el registro que necesitamos
        /// </summary>
        /// <response code="200">Se creo correctamente</response>
        /// <response code="404">Cliente no encontrado</response>
        /// <response code="500">Oops! No se pudo buscar el Cliente</response>

        [HttpPut("{id}")]
        public ActionResult Put([FromBody] Cliente cliente, int id)
        {
            if (id != cliente.idCliente)
            {
                
                return BadRequest();//NO se encontro id del registro
            }
            else
            {
                
                _context.ClienteRepo.Update(cliente);//modifica registro
                _context.Save();
                return Ok();
            }

        }

        //DELETE
        //-----------------------------------------------------------
        /// <summary>
        ///  borra registro de la base de datos.
        /// </summary>
        /// <param name="id" example="123">idClienete</param>
        /// 
        /// <response code="200">Se creo correctamente</response>
        /// <response code="404">Cliente no encontrado</response>
        /// <response code="500">Oops! No se pudo buscar el Cliente</response>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var entity = _context.ClienteRepo.GetById(id);

            if (entity == null)
            {
                
                return NotFound();
            }
            else
            {
                _context.ClienteRepo.Delete(id);//borra el registro
                _context.Save();
            }
            

            return Ok();


        }
    }
}
