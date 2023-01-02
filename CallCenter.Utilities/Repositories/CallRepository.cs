using CallCenter.Entities.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenter.Utilities.Repositories
{
    public  class CallRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDBContext _context;

        public CallRepository(ApplicationDBContext context)
        {
            _context=context;
        }

        public IEnumerable<TEntity> GetSP(string sp, int number)
        {            
           return (IEnumerable<TEntity>)_context.SPClienteBM.FromSqlRaw(sp, new SqlParameter("@CEDULA", number)).ToList();

        }
    }
}
