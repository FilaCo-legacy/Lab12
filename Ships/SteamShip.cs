using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ships
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
        public override object Clone()
        {
            return new SteamShip("Клон " + this.Name, this.DateReleased, this.MaxSpeed, this.EnginePower, 
                this.NumOfPipes);
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
        public SteamShip(string nameValue, string dateValue,  int maxSpeedValue,
            int enginePowerValue,int numOfPipesValue) : base(nameValue, dateValue,maxSpeedValue)
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
