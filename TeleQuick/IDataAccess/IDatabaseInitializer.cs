using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TeleQuick.IDataAccess
{
    public interface IDatabaseInitializer
    {
        Task SeedAsync();
    }
}
