﻿using API.Core.Business.DBContext;
using API.Core.Business.Entities;
using API.Data.Core.Repository.InterfaceRepo;
using API.Generic.Core.Genericos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Data.Core.Repository
{
    public class ClienteRepostory : GenericRepository<Cliente>, IClientesRepository
    {
        public ClienteRepostory(AppDbContext db) : base(db)
        {

        }
    }
}
