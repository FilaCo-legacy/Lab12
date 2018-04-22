using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ships
{
    class SailingShip:Ship
    {
        protected int _numOfSails;
        public int NumOfSails
        {
            get { return _numOfSails; }
            set
            {
                if (value < 1)
                    _numOfSails = 1;
                else
                    _numOfSails = value;
            }
        }
        protected int _numOfMasts;
        public int NumOfMasts
        {
            get { return _numOfMasts; }
            set
            {
                if (value < (NumOfSails + 2) / 3)
                    _numOfMasts = (NumOfSails + 2) / 3;
                else
                    _numOfMasts = value;
            }
        }
        public override object Clone()
        {
            return new SailingShip("Клон " + this._name, this._dateReleased, this.MaxSpeed,
    this.NumOfSails, this.NumOfMasts);
        }
        public override object ShallowClone()
        {
            return (SailingShip)MemberwiseClone();
        }
        public SailingShip():base()
        {
            NumOfSails = rnd.Next(1, 5);
            NumOfMasts = rnd.Next(NumOfSails, NumOfSails * 3);
        }
        public SailingShip(string nameValue, string dateValue,int maxSpeedValue,
            int numOfSailsValue, int numOfMastsValue):base(nameValue, dateValue, maxSpeedValue)
        {
            NumOfSails = numOfSailsValue;
            NumOfMasts = numOfMastsValue;
        }
        public override void Show()
        {
            base.Show();
            Console.WriteLine(@"Количество парусов: {0}
Количество мачт: {1}", NumOfSails, NumOfMasts);
        }
    }
}
