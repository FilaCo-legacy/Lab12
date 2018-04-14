using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная11
{
    public class SortByGuns:IComparer
    {
        int IComparer.Compare(object obj1, object obj2)
        {
            IWarVessel cur1 = (IWarVessel)obj1;
            IWarVessel cur2 = (IWarVessel)obj2;
            if (cur1.Guns > cur2.Guns)
                return 1;
            else if (cur1.Guns < cur2.Guns)
                return -1;
            return 0;
        }
    }
}
