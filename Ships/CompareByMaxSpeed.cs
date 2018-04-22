using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ships
{
    public class CompareByMaxSpeed:IComparer
    {
        public int Compare(object o1, object o2)
        {
            Ship curShip1 = (Ship)o1;
            Ship curShip2 = (Ship)o2;
            if (curShip1.MaxSpeed > curShip2.MaxSpeed)
                return 1;
            if (curShip1.MaxSpeed < curShip2.MaxSpeed)
                return -1;
            return 0;
        }
    }
}
