using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная11
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
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string DateReleased
        {
            get { return _dateReleased; }
            set
            {
                if (Program.CheckReg(value, regDateReleasedValue))
                    _dateReleased = value;
                else
                    _dateReleased = "Incorrect";
            }
        }
        public string PortName
        {
            get { return _portName; }
            set { _portName = value; }
        }
        public double Displacement
        {
            get { return _displacement; }
        }
        public override object Clone()
        {
            return new SailingShip("Клон " + this._name, this._dateReleased, this._portName, this._displacement, this.MaxSpeed,
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
        public SailingShip(string nameValue, string dateValue, string portValue, double displacementValue, int maxSpeedValue,
            int numOfSailsValue, int numOfMastsValue):base(nameValue, dateValue,portValue,  displacementValue, maxSpeedValue)
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
