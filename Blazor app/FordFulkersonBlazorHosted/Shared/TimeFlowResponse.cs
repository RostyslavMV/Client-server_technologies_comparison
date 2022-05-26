using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FordFulkersonBlazor.Shared
{
    public class TimeFlowResponse
    {
        public int flow { get; private set; }
        public long timeMs { get; private set; }

        public TimeFlowResponse(int flow, long timeMs)
        {
            this.flow = flow;
            this.timeMs = timeMs;
        }

    }
}
