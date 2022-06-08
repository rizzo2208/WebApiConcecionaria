using API.Data.Core.Repository.InterfaceRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Uses.Cases.UOWork
{
    public interface IUnitOfWork : IDisposable
    {
        IClientesRepository ClienteRepo { get; }
        IVentaRepository VentaRepo { get; }
        IVehiculoRepository VehiculoRepo { get; }
        IUsuarioRepository UsuarioRepo { get; }

        void Save();
    }
}
