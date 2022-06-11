using API.Core.Business.Authentication.UserRequest;
using API.Core.Business.Authentication.UserResponse;
using API.Core.Business.Entities;
using API.Uses.Cases.Servicios;
using API.Uses.Cases.UOWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace WebApiConcecionaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _usuarioService;
        private readonly IUnitOfWork _uow;
        
        public LoginController(IUserService usuarioService, IUnitOfWork uow)
        {
            _usuarioService = usuarioService;
            _uow = uow;
        }
        [HttpPost]
        public ActionResult Login([FromBody] UserRequest req)
        {
            var response = _usuarioService.Login(req.Email, req.Password);

            if (response == null)
            {
                
                return Unauthorized();
            }
            var token = _usuarioService.GetToken(response);
            return Ok(new
            {
                token = token,
                usuario = response
            });
        }
        [HttpPost("Registro")]
        public ActionResult RegistrarUsuario([FromBody] UserRequest user)
        {
            if (_uow.UsuarioRepo.ExisteUsuario(user.Email.ToLower()))
            {
                return BadRequest("Ya existe un cuenta asociada a ese Email");
            }
            UserResponse res = _usuarioService.Registrar(user, user.Password);
            return Ok(res);
        }
    }
}
