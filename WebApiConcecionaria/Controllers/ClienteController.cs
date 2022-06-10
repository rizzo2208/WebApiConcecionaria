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

        private readonly ILogger<ClienteController> _logger;

        public ClienteController(IUnitOfWork context, ILogger<ClienteController> logger)
        {
            _context = context;
            _logger = logger;
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
            _logger.LogInformation("get Cliente Funcionando");
            var entidad = _context.ClienteRepo.GetAll();
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
            _logger.LogInformation("Post Cliente Funcionando");
            _context.ClienteRepo.Insert(cliente);
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
                _logger.LogError("NO se encontro id del registro");
                return BadRequest();
            }
            else
            {
                _logger.LogInformation("Put cliente funcionando");
                _context.ClienteRepo.Update(cliente);
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
                _logger.LogError("NO se encontro registro para eliminar");
                return NotFound();
            }
            else
            {
                _logger.LogInformation("DELETE ON");
                _context.ClienteRepo.Delete(id);
                _context.Save();
            }
            

            return Ok();


        }
    }
}
