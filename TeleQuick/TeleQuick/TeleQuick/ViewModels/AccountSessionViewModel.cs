using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeleQuick.ViewModels
{
    public class AccountSessionViewModel
    {
        public int Id { get; set; }

        public string LoginUser { get; set; }

        public string LoginUserPassword { get; set; }

        public bool IsValid { get; set; }

        public string ConcessionaryName { get; set; }
    }
}
