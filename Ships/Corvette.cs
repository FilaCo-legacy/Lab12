using System;

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
        public override object Clone()
        {
            return new Corvette("Клон " + this.Name, this.DateReleased, this.MaxSpeed,
                     this.EnginePower, this.NumOfPipes, this.NumOfGuns, this.NumOfShells);
        }
        public override object ShallowClone()
        {
            return (Corvette)MemberwiseClone();
        }
        public Corvette():base()
        {
            NumOfGuns = rnd.Next(1, 21);
            NumOfShells = rnd.Next(NumOfGuns, NumOfGuns * 10);
        }
        public Corvette(string nameValue, string dateValue, int maxSpeedValue,
            int enginePowerValue, int numOfPipesValue, int numOfGunsValue, int numOfShellsValue) 
            : base(nameValue, dateValue, maxSpeedValue,  enginePowerValue, numOfPipesValue)
        {
            NumOfGuns = numOfGunsValue;
            NumOfShells = numOfShellsValue;
            EnginePower = enginePowerValue;
            NumOfPipes = numOfPipesValue;
        }
        public override void Show()
        {
            base.Show();
            Console.WriteLine(@"Количество пушек: {0}
Боезапас: {1}", NumOfGuns, NumOfShells);
        }
    }
}
