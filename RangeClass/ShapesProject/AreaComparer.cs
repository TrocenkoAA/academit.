using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesProject
{
    class AreaComparer : IComparer<IShape>
    {
        public int Compare(IShape p1, IShape p2)
        {
            if (p1.GetArea() < p2.GetArea())
            {
                return 1;
            }
            else if (p1.GetArea() > p2.GetArea())
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
