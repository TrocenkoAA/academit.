﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesProject
{
    class AreaComparer : IComparer<IShape>
    {
        public int Compare(IShape p1, IShape p2)
        {
            return p1.GetArea().CompareTo(p2.GetArea());
        }
    }
}
