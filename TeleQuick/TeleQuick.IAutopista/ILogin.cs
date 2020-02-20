using ScrapySharp.Network;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TeleQuick.Core.IAutopista
{
    public interface ILogin
    {
        string GetUri();
        string GetMainForm();
        Dictionary<string, string> GetDictionary();
        Task<bool> LoginValidateAU();
        Task<WebPage> LoginWebPage();
    }
}
