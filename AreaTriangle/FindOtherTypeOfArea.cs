using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaTriangle
{
    public class FindOtherTypeOfArea
    {
        public double Area(int sidesCount, double sidesLength)
        {
            return sidesCount*sidesLength*sidesLength/(4*Math.Tan(Math.PI/sidesCount));
        }

    }
}
