using System;
using System.Collections.Generic;

namespace Business.Medicines
{
    public class Item
    {
        public int Id { get; set; }
        public int CUF { get; set; }
        public string BarCode { get; set; }
        public string Description { get; set; }
        public string Indications { get; set; }
        public string Considerations { get; set; }
        public string AdverseEffects { get; set; }
        public string Posology { get; set; }
        public double Margin { get; set; }
        public double PublicPrice { get; set; }
        public Package Package { get; set; }
        public Formula Formula { get; set; }
        public PharmacologicalAction PharmacologicalAction { get; set; }
    }
}
