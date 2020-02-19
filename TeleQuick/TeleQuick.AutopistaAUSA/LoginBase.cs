using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeleQuick.IAutopista;

namespace TeleQuick.Autopista.Login
{
    public abstract class LoginBase
    {
        protected AccountSession _accountSession;
        protected IConnectionAU _connect;



        public virtual string GetMainForm()
        {
            return _accountSession.Concessionary.MainForm;
        }

        public virtual string GetUri()
        {
            return _accountSession.Concessionary.Uri;
        }
    }
}
