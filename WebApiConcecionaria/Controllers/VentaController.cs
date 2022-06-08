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
    public class VentaController : ControllerBase
    {
        private readonly IUnitOfWork _context;

        public VentaController(IUnitOfWork context)
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
        public ActionResult<IEnumerable<Venta>> Get()
        {
            var entidad = _context.VentaRepo.GetAll();
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
        public ActionResult Post([FromBody] Venta venta)
        {
            _context.VentaRepo.Insert(venta);
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
        public ActionResult Put([FromBody] Venta venta, int id)
        {
            try
            {
                _context.VentaRepo.Update(venta);
                _context.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
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
            var entity = _context.VentaRepo.GetById(id);
            if (entity == null)
            {
                return NotFound();
            }
            _context.VentaRepo.Delete(id);
            _context.Save();

            return Ok();
        }
    }
}
