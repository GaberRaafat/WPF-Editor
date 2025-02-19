using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Editor.Model
{
    public class Rectangle : Shape
    {
        public string Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Rectangle() { }
        public Rectangle(string name, int width, int height)
        {
            Name = name;
            Width = width;
            Height = height;
        }
    }
}
