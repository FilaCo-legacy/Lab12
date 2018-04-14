using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная11
{
    interface IWarVessel:ICloneable,IComparable
    {
        int MaxSpeed { get; }
        int Guns { get; }
        int Shells { get; }
        void Show();
    }
}
