using System;
using System.Threading.Tasks;

namespace IProvider
{
    public interface IProviderAU
    {
        Task<bool> ValidateConnection();
    }
}
