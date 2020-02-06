using Business.MedicalInsurances;
using System;
using System.Collections.Generic;

namespace Business.BranchOffices
{
    public class BranchOfficeLite
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Telephone { get; set; }

        public int CityId { get; set; }

        public string CyberMapX { get; set; }

        public string CyberMapY { get; set; }

        public bool IsOpen24 { get; set; }

        public bool IsPickupEMC { get; set; }

        public List<BranchOfficeTimeTable> TimeTables { get; set; }
    }
}
