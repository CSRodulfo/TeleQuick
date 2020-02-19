using Business.Models;
using IProvider;
using System;
using System.Threading.Tasks;
using TeleQuick.Core.IAutopista;
using TeleQuick.IAutopista;

namespace Provider
{
    public class ProviderAUSA  : IProviderAU
    {

        IConnectionAU _connection;
        ILogin _login ;

        public ProviderAUSA(IConnectionAU connection)
        {
            _connection = connection;
            _login = new TeleQuick.AutopistaAUSA.Login();
        }

        public async Task<AccountSession> ValidateConnection(AccountSession account)
        {
            try
            {

                await this._connection.LoginWebPage(_login);


                throw new NotImplementedException();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

    }
}
