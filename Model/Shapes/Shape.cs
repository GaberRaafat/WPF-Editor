using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor.Model
{
    public class Shape
    {
        public Guid Id { get; set; }

        public Shape()
        {
            Id = Guid.NewGuid();
        }
        public Shape(Guid id)
        {
            Id = id;
        }
    }
}
