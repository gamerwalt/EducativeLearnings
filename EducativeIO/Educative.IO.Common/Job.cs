using System;
using System.Collections.Generic;
using System.Text;

namespace Educative.IO.Common
{
    public class Job
    {
        public int Start { get; set; }
        public int End { get; set; }
        public int CpuLoad { get; set; }

        public Job(int start, int end, int load)
        {
            Start = start;
            End = end;
            CpuLoad = load;
        }

        public override string ToString()
        {
            return $"Start: {Start}, End: {End}, Load: {CpuLoad}.";
        }
    }
}
