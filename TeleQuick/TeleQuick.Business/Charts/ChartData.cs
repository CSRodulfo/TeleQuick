using System;
using System.Collections.Generic;
using System.Text;

namespace TeleQuick.Business.Charts
{
    public class ChartData
    {
        public string label { get; set; }

        public IList<ChartYear> data { get; set; }

    }
}
