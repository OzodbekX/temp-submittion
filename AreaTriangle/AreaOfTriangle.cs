using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AreaTriangle
{
    public class AreaOfTriangle
    {
        public double Area(float a, float b, float c)
        {
            if (a + b <= c || a + c <= b || b + c <= a)
            {
                Console.WriteLine("Hello pleace anter three sides of triangle");
                return 0;
            }
            float s = (a + b + c) / 2;
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c)); ;

        }
        public bool IsThisRectangularTriangle(float a, float b, float c)
        {
            if (c * c == (a * a + b * b) || a * a == (c * c + b * b) || b * b == (a * a + c * c)) return true;
            else return false;
        }
    }
}
