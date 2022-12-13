using System;
using System.Windows;

namespace TriangleArea
{
    public class Class1
    {
        double area;
        public double Area(float a,float b, float c)
        {
            if (a+b < c || c + b < a|| a + c < b) {
                MessageBox.Show("Hello pleace anter three sides of triangle");
                return 0;
            }
            float s=(a+b+c)/2;
            area=Math.Sqrt(s*(s-a)*(s-b)*(s-c));
            return area;

        }
        public void Display()
        {
            MessageBox.Show("Hello pleace anter three sides of triangle");
        }
    }
}
