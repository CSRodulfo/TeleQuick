using Business.Models;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeleQuick.Core.IAutopista;
using TeleQuick.IAutopista;

namespace TeleQuick.Autopista.Login
{
    public abstract class LoginBase : ILogin
    {
        protected AccountSession _accountSession;
        protected IConnectionAU _connect;

        public Dictionary<string, string> GetDictionary()
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> LoginValidateAU()
        {
            throw new NotImplementedException();
        }

        public virtual string GetMainForm()
        {
            return _accountSession.Concessionary.MainForm;
        }

        public virtual string GetUri()
        {
            return _accountSession.Concessionary.Uri;
        }

        public virtual async Task<WebPage> LoginWebPage()
        {
            return await _connect.LoginWebPage(this);
        }
    }
}
