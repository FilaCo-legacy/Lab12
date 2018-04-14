using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная11
{
    class SteamShip:Ship
    {
        protected int _enginePower;
        protected int _numOfPipes;
        public int EnginePower
        {
            get { return _enginePower; }
            set
            {
                if (value < 20)
                    _enginePower = 20;
                else
                    _enginePower = value;
            }
        }
        public int NumOfPipes
        {
            get { return _numOfPipes; }
            set
            {
                if (value < 1)
                    _numOfPipes = 1;
                else
                    _numOfPipes = value;
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
            return new SteamShip("Клон " + this._name, this._dateReleased, this._portName, this._displacement, this.MaxSpeed,
                    this.EnginePower, this.NumOfPipes);
        }
        public override object ShallowClone()
        {
            return (SteamShip)MemberwiseClone();
        }
        public SteamShip():base()
        {
            EnginePower = rnd.Next(20, 500);
            NumOfPipes = rnd.Next(1, 6);
        }
        public SteamShip(string nameValue, string dateValue, string portValue,double displacementValue, int maxSpeedValue,
            int enginePowerValue,int numOfPipesValue) : base(nameValue, dateValue,portValue, displacementValue, maxSpeedValue)
        {
            EnginePower = enginePowerValue;
            NumOfPipes = numOfPipesValue;
        }
        public override void Show()
        {
            base.Show();
            Console.WriteLine(@"Мощность двигателя (в л.с): {0}
Количество паровых труб: {1}", EnginePower, NumOfPipes);
        }
    }
}
