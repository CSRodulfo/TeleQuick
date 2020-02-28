using TeleQuick.Business.Models;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeleQuick.Core.IAutopista;

namespace TeleQuick.Autopista.Login
{
    public abstract class LoginBase : ILogin
    {
        protected AccountSession _accountSession;
        protected IConnectionAU _connect;

        public LoginBase(IConnectionAU connect, AccountSession accountSession)
        {
            _accountSession = accountSession;
            _connect = connect;
        }
        public virtual Dictionary<string, string> GetDictionary()
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
