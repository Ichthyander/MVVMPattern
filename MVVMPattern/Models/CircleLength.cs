using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMPattern.Models
{
    static class CircleLength
    {
        public static double GetCircleLength(double r) => 2*Math.PI*r;
    }
}
