using Business.BranchOffices;
using Business.IRestServices;
using Business.StockUnificado;
using IServices.BranchOffices;
using IServices.StockUnifieds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.StockUnifieds
{
    public class StockUnifiedService : IStockUnifiedService
    {
        private readonly IStockUnifiedRestService stockUnifiedRestService;
        private readonly IBranchOfficeService branchOfficeService;

        public StockUnifiedService(IStockUnifiedRestService stockUnifiedRestService, IBranchOfficeService branchOfficeService)
        {
            this.stockUnifiedRestService = stockUnifiedRestService;
            this.branchOfficeService = branchOfficeService;
        }

        public async Task<List<MedicineAvailableReturn>> Search(IEnumerable<MedicineStock> desiredMedicines)
        {
            var allBranchOffices = await this.branchOfficeService.GetAllWithMedicineReservation();
            var medicineAvailableRequest = new MedicineAvailableRequest()
            {
                SucursalList = allBranchOffices.Select(x => x.Id).ToList(),
                CufCantidadList = desiredMedicines.ToList(),
            };

            var medicineStock = await this.stockUnifiedRestService.GetMedicineAvailable(medicineAvailableRequest);

            var groupedMedicineAvailableStock =
                medicineStock
                    .Where(x => x.Cantidad > 0)
                    .GroupBy(x => x.Sucursal);

            var medicineAvailableReturn = new List<MedicineAvailableReturn>();

            foreach (var branchOfficeStock in groupedMedicineAvailableStock)
            {
                var partialAvailability = false;
                var branchOfficeMedicineStock = new List<MedicineStock>();

                var branchOffice = allBranchOffices.First(x => x.Id == branchOfficeStock.Key);

                if (this.BranchOfficeHasAllDesiredMedicines(desiredMedicines, branchOfficeStock))
                {
                    partialAvailability = true;
                }

                foreach (var availableMedicine in branchOfficeStock)
                {
                    branchOfficeMedicineStock.Add(new MedicineStock()
                    {
                        Cuf = availableMedicine.Cuf,
                        Cantidad = availableMedicine.Cantidad,
                    });

                    if (!partialAvailability)
                    {
                        var desiredMedicine = desiredMedicines.First(x => x.Cuf == availableMedicine.Cuf);
                        if (this.DesiredQuantityIsInStock(availableMedicine, desiredMedicine))
                        {
                            partialAvailability = true;
                        }
                    }
                }

                medicineAvailableReturn.Add(new MedicineAvailableReturn(branchOffice, branchOfficeMedicineStock, partialAvailability));
            }

            return medicineAvailableReturn;
        }

        private bool BranchOfficeHasAllDesiredMedicines(IEnumerable<MedicineStock> desiredMedicines, IGrouping<int, MedicineAvailableResponse> branchOfficeStock)
        {
            return desiredMedicines.Count() > branchOfficeStock.Count();
        }

        private bool DesiredQuantityIsInStock(MedicineAvailableResponse availableMedicine, MedicineStock desiredMedicine)
        {
            return availableMedicine.Cantidad < desiredMedicine.Cantidad;
        }
    }
}