using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenter.Utilities.Repositories
{
    public  interface IRepository<TEntity>
    {       
        IEnumerable<TEntity> GetSP(string sp, int number);
    }
}
