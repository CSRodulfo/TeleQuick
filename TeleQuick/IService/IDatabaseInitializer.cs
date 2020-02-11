using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IService
{
    public interface IDatabaseInitializer
    {
        Task SeedAsync();
    }
}
