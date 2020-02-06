using Business.BranchOffices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.StockUnificado
{
    public class MedicineAvailableReturn
    {
        public BranchOfficeLite BranchOffice { get; set; }
        public List<MedicineStock> MedicinesStock { get; set; }
        public bool PartialAvailability { get; set; }

        public MedicineAvailableReturn(BranchOfficeLite branchOffice, List<MedicineStock> medicinesStock, bool partialAvailability)
        {
            this.BranchOffice = branchOffice;
            this.MedicinesStock = medicinesStock;
            this.PartialAvailability = partialAvailability;
        }
    }
}