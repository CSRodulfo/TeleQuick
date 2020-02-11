using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IDataAccess
{
    public interface IDatabaseInitializer
    {
        Task SeedAsync();
    }
}
