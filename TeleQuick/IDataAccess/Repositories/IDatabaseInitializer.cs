using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IDataAccess.Repositories
{
    public interface IDatabaseInitializer
    {
        Task SeedAsync();
    }
}
