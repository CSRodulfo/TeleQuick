﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeleQuick.ViewModels
{
    public class VehicleViewModel
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }
        public string RegistrationNumber { get; set; }

        public int TAGNumber { get; set; }
    }
}
