using System;
using System.Collections.Generic;
using System.Text;

namespace Business.BranchOffices
{
    public class BranchOfficeTimeTable
    {
        public int Id { get; set; }
        public int DayOfWeek { get; set; }
        public TimeSpan Open { get; set; }
        public TimeSpan Close { get; set; }
        public TimeSpan? Open1 { get; set; }
        public TimeSpan? Close1 { get; set; }
    }
}
