using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor.Model
{
    public class Circle : Shape
    {
        public string Name { get; set; }
        public int Radius1 { get; set; }
        public int Radius2 { get; set; }
        public Circle() { }
        public Circle(string name, int radius1,int radius2)
        {
            Name = name;
            Radius1 = radius1;
            Radius2 = radius2;
        }
    }
}
