using ScrapySharp.Network;
using System.Threading.Tasks;

namespace TeleQuick.Core.IAutopista
{
    public interface IConnectionAU
    {
        Task<WebPage> LoginWebPage(ILogin login);
        Task<WebPage> GetWebPage(string Uri);
    }
}
