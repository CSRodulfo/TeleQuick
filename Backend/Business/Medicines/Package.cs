using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Medicines
{
    public class Package
    {
        public int Id { get; set; }

        public string Potency { get; set; }

        public int UnitPotencyId { get; set; }

        public string Dosis
        {
            get { return string.Concat(this.Potency, " ", this.UnitPotency.Description); }
        }
        public UnitPotency UnitPotency { get; set; }

        public PackageDescription PackageDescription { get; set; }
    }
}