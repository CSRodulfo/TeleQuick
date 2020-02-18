using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeleQuick.Core.IAutopista;

namespace Business.Models
{
    public partial class Concessionary
    {
        public async Task<ILogin> GetLogin()
        {
            ILogin login = null;

            AutopistasConstants autopista = (AutopistasConstants)this.Id;

            switch (autopista)
            {
                case AutopistasConstants.AUSA:
                    login = new TeleQuick.AutopistaAUSA.Login();
                    break;
                case AutopistasConstants.AUSOL:
                    break;
                case AutopistasConstants.AUBASA:
                    break;
                case AutopistasConstants.AUSUR:
                    break;
                case AutopistasConstants.AUOESTE:
                    break;
                case AutopistasConstants.CEAMSE:
                    break;
                default:
                    break;
            }

            return login;
        }
    }
}
