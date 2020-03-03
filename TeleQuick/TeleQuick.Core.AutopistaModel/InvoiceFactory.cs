using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeleQuick.Business.Models;

namespace TeleQuick.Core.Autopista.Model
{
    public abstract class InvoiceFactory
    {
        protected IEnumerable<Vehicle> _vehicles;
        public InvoiceFactory(IEnumerable<Vehicle> vehicles)
        {
            _vehicles = vehicles;
        }

        public Vehicle GetVehicle(string registration)
        {
            return _vehicles.Where(x => x.RegistrationNumber == registration).First();
        }

        public Vehicle GetVehicle(int tag)
        {
            return _vehicles.Where(x => x.TagRfids.Any(z => z.Tagnumber == tag)).First();
        }
    }
}
