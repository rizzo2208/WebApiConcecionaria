using API.Core.Business.DBContext;
using API.Data.Core.Repository;
using API.Data.Core.Repository.Class;
using API.Data.Core.Repository.InterfaceRepo;
using Microsoft.Extensions.Logging;
using Middleware.Logger;

namespace API.Uses.Cases.UOWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly ILogger _logger;
        public  LoggerCustom loggerCustom { get;private set; }

        public IClientesRepository ClienteRepo { get; private set; }

        public IVentaRepository VentaRepo { get; private set; }

        public IVehiculoRepository VehiculoRepo { get; private set; }
        
        public IUsuarioRepository UsuarioRepo { get; private set; }
        


        public UnitOfWork(AppDbContext context, ILoggerFactory logger)
        {
            _context = context;
            _logger = logger.CreateLogger("logs");
            loggerCustom = new LoggerCustom(_logger);

            ClienteRepo = new ClienteRepostory(context,loggerCustom);
            VentaRepo = new VentaRepository(context,loggerCustom);
            VehiculoRepo = new VehiculoRepository(context,loggerCustom);
            UsuarioRepo = new UsuarioRepositorio(context,loggerCustom);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
