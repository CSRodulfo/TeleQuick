using Business.MedicalInsurances;
using System;
using System.Collections.Generic;

namespace Business.BranchOffices
{
    public class BranchOffice : BranchOfficeLite
    {
        public List<MedicalInsurance> MedicalInsurances { get; set; }

        public List<BranchOfficeService> Services { get; set; }
    }
}
