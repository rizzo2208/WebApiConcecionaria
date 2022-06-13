using API.Core.Business.Entities;
using API.Uses.Cases.UOWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Middleware.Logger;

namespace WebApiConcecionaria.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly IUnitOfWork _context;
        private readonly LoggerCustom loggerCustom;
        private readonly ILogger<ClienteController> _logger;

        public ClienteController(IUnitOfWork context, ILogger<ClienteController> logger)
        {
            _context = context;
            _logger = logger;
            loggerCustom = new LoggerCustom(_logger);
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
            loggerCustom.Info("Llamado Get Cliente"); 
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
            loggerCustom.Info("Insercion Del Regitro Nuevo");
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
                loggerCustom.Error("No Se Encontro El Regisro Solicitado");
                return BadRequest();//NO se encontro id del registro
            }
            else
            {
                loggerCustom.Info("Se Modifico El Regisro Solicitado");
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
                loggerCustom.Error("No Se Encontro El Regisro Solicitado");
                return NotFound("No Se Encontro El Regisro Solicitado");
            }
            else
            {
                loggerCustom.Info("El ]Registo Ah Sido Borrado");
                _context.ClienteRepo.Delete(id);//borra el registro
                _context.Save();
            }
            

            return Ok();


        }
    }
}
