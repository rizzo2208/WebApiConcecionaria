using API.Core.Business.Entities;
using API.Uses.Cases.UOWork;
using API.Generic.Core;
using FakeItEasy;
using WebApiConcecionaria.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Testing
{
    public class UnitTest1
    {
        private readonly ILogger <ClienteController> logger = A.Fake<ILogger<ClienteController>>();
        private readonly IUnitOfWork _context = A.Fake<IUnitOfWork>();
        Cliente cliente = new Cliente()
        {
            idCliente = 1,
            Nombre = "Damian",
            dni = "33413924",
            dieccion = " guanahani 6906"
        };

        Vehiculo vehiculo = new Vehiculo()
        {

        };

        //-----------------------GET CLIENTE------------------------
        [Fact]
        public void Test1()
        {
            var controller = new ClienteController(_context,logger);//crea una instancia
            var result = controller.Get();//invoca el get del cotrolador
            Assert.NotNull(result);//muestra el resultado
        }
        //----------------------------------------------------------

        //-----------------------POST CLIENTE-----------------------
        [Fact]
        public void Test2()
        {
            var controller = new ClienteController(_context, logger);//crea una instancia
            var result = controller.Post(cliente);//invoca el post del cotrolador
        }
        //----------------------------------------------------------

        //--------------------DELETE CLIENTE------------------------
        [Fact]
        public void Test3()
        {
            var controller = new ClienteController(_context, logger);//crea una instancia
            var result = controller.Delete(1);//invoca el delete del cotrolador
            Assert.NotNull(result);
        } 
        
        [Fact]
        public void Test4()
        {
            var controller = new ClienteController(_context, logger);//crea una instancia
            var ClienteNuevo = controller.Post(cliente);
            var result = controller.Delete(cliente.idCliente);//invoca el get del cotrolador
            Assert.IsType<OkResult>(result);
        } 
        
        [Fact]
        public void Test5()
        {
            A.CallTo(() => _context.ClienteRepo.GetById(1)).Returns(null);//
            var controller = new ClienteController(_context, logger);//crea una instancia
            var result = controller.Delete(1);//invoca el get del cotrolador
            Assert.IsType<NotFoundResult>(result);


        }
        //---------------------------------------------------------

        //------------------------PUT CLIENTE----------------------

        //---------------------------------------------------------


        //**********************VEHICULO******************************

        //---------------------

    }
}