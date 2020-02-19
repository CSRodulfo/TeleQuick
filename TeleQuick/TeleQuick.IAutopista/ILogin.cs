using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeleQuick.IAutopista;

namespace TeleQuick.Core.IAutopista
{
    public interface ILogin
    {
        string GetUri();

        string GetMainForm();
        Dictionary<string, string> GetDictionary();
        Task<bool> LoginValidateAU(IConnectionAU connect);
    }
}
