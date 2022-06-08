using API.Core.Business.Authentication.UserRequest;
using API.Core.Business.Authentication.UserResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace API.Uses.Cases.Servicios
{
    public interface IUserService
    {
        UserResponse Registrar(UserRequest usuario, string password);
        UserResponse Login(string email, string password);
        string GetToken(UserResponse usuario);
    }
}
