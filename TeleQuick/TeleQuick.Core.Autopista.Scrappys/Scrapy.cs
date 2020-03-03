using System;
using System.Collections.Generic;
using System.Text;
using TeleQuick.Core.IAutopista;

namespace TeleQuick.Core.Autopista.Scrappys
{
    public abstract class Scrapy
    {
        protected IConnectionAU _connection;
        public Scrapy(IConnectionAU connection)
        {
            _connection = connection;
        }
    }
}
