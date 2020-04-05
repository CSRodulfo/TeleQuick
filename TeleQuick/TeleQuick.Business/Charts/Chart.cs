using System;
using System.Collections.Generic;
using System.Text;

namespace TeleQuick.Business.Charts
{
    public class Chart
    {
        public IEnumerable<ChartData> chartData { get; set; }
        public IEnumerable<string> labels { get; set; }
    }
}
