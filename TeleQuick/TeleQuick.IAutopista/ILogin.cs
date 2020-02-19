using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace TeleQuick.Core.IAutopista
{
    public interface ILogin
    {
        string GetUri();

        string GetMainForm();
        Dictionary<string, string> GetDictionary();
        bool LoginValidateAU(WebPage webPage);
    }
}
