using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeleQuick.SignalR
{
    public class Message
    {
        public string Description { get; set; }

        public string Value { get; set; }
    }
}
