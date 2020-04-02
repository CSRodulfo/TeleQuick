using System;
using System.Collections.Generic;
using System.Text;

namespace TeleQuick.Business.Charts
{
    public class ChartData
    {
        public string label { get; set; }

        public IEnumerable<ChartYear> data { get; set; }
    }
}
