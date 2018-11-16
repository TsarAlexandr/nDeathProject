using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace nDeathProject.Models
{
    public class ChartEntity
    { 
        [Required]
        public int ACoeff { get; set; }
        [Required]
        public int BCoeff { get; set; }
        [Required]
        public int CCoeff { get; set; }
        [Required]
        public int Step { get; set; }
        [Required]
        public int LowerBorder { get; set; }
        [Required]
        public int UpperBorder { get; set; }
    }
}
