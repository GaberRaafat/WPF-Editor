using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Editor.Model
{
    public class Line : Shape
    {
        public string Name { get; set; }

        public double X1 { get; set; }
        public double X2 { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
        public Line() { }
        public Line(string name,double x1, double x2, double y1, double y2)
        {
            Name = name;
            X1 = x1;
            X2 = x2;
            Y1 = y1;
            Y2 = y2;
        }

    }
}
