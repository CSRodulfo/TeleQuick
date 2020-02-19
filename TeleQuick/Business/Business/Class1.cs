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
        public AutopistasConstants GetAutopista()
        {
            return (AutopistasConstants)this.Id;
        }
    }
}
