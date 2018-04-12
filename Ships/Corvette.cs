using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ships
{
    public class Corvette:SteamShip
    {
        protected int _numOfGuns;
        public int NumOfGuns
        {
            get { return _numOfGuns; }
            set
            {
                if (value >= 1)
                    _numOfGuns = value;
                else
                    _numOfGuns = 1;
            }
        }
        protected int _numOfShells;
        public int NumOfShells
        {
            get { return _numOfShells; }
            set
            {
                if (value >= 0)
                    _numOfShells = value;
                else
                    _numOfShells = 0;
            }
        }
        protected double _caliberOfGuns;
        public double CaliberOfGuns
        {
            get { return _caliberOfGuns; }
            set
            {
                if (value >= 1)
                    _caliberOfGuns = value;
                else
                    _caliberOfGuns = 7.62;
            }
        }
        public Corvette():base()
        {
            NumOfGuns = rnd.Next(1, 21);
            NumOfShells = rnd.Next(NumOfGuns, NumOfGuns * 10);
            CaliberOfGuns = rnd.Next(5, 100) + rnd.NextDouble();
        }
        public Corvette(string nameValue, string dateValue, string portValue, double displacementValue, int maxSpeedValue,
            int enginePowerValue, int numOfPipesValue, int numOfGunsValue, int numOfShellsValue, double caliberValue) 
            : base(nameValue, dateValue, portValue, displacementValue, maxSpeedValue,  enginePowerValue, numOfPipesValue)
        {
            NumOfGuns = numOfGunsValue;
            NumOfShells = numOfShellsValue;
            CaliberOfGuns = caliberValue;
            EnginePower = enginePowerValue;
            NumOfPipes = numOfPipesValue;
        }
        public override void Show()
        {
            base.Show();
            Console.WriteLine(@"Количество пушек: {0}
Боезапас: {1}
Калибр пушек (в мм): {2: 0.##}", NumOfGuns, NumOfShells, CaliberOfGuns);
        }
    }
}
