using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nDeathProject.Models
{
    public class ChartEntity
    {
        public int ACoeff { get; set; }
        public int BCoeff { get; set; }
        public int CCoeff { get; set; }
        public int Step { get; set; }
        public int LowerBorder { get; set; }
        public int UpperBorder { get; set; }
    }
}
