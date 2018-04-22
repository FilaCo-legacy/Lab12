using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ships
{
    public class CompareByDateReleased:IComparer
    {
        public int Compare(object o1, object o2)
        {
            Ship curShip1 = (Ship)o1;
            Ship curShip2 = (Ship)o2;
            return DateTime.Compare(DateTime.Parse(curShip1.DateReleased), DateTime.Parse(curShip2.DateReleased));
        }
    }
}
