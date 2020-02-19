using Business.Models;
using IProvider;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeleQuick.Autopista.Login;
using TeleQuick.Core.IAutopista;
using TeleQuick.IAutopista;

namespace Provider
{
    public class ProviderAUSOL : IProviderAU
    {
        IConnectionAU _connection;
        ILogin _login;

        public ProviderAUSOL(IConnectionAU connection, AccountSession accountSession)
        {
            _connection = connection;
            _login = new LoginAUSOL(connection, accountSession);
        }

        public async Task<bool> ValidateConnection()
        {
            try
            {
                return await this._login.LoginValidateAU();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
