using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Лабораторная11
{
    public abstract class Ship: IWarVessel
    {
        public static string regDateReleasedValue = @"(?<=^|\s)((0{0,1}\d|1\d|2\d|3[01])(\.|\/)(0{0,1}[13578]|1[02])\3(1[7-9]\d\d|200\d))|((0{0,1}\d|1\d|2\d|30)(\.|\/)(0{0,1}[469]|11)\8(1[7-9]\d\d|200\d))|((0{0,1}\d|1\d|2[0-8])(\.|\/)(0{0,1}2)\13(1[7-9]\d\d))(?=$|\s)";
        protected static string[] listShipNames;
        protected static string[] listPortNames;
        protected static Random rnd = new Random();
        protected int _maxSpeed;
        public int MaxSpeed { get { return _maxSpeed; } }
        protected string _name;
        protected string _dateReleased;
        protected string _portName;
        protected double _displacement;
        public Ship()
        {
            if (listShipNames == null)
            InitRandomNames();
            _name = listShipNames[rnd.Next(listShipNames.Length)];
            _dateReleased = new DateTime(rnd.Next(1700, 2018), rnd.Next(1, 13), rnd.Next(1, 28)).ToShortDateString();
            _portName = listPortNames[rnd.Next(listPortNames.Length)];
            _displacement = rnd.Next(1, 200) + rnd.NextDouble();
            _maxSpeed = rnd.Next(10, 32);
        }
        public Ship(string nameValue, string dateValue, string portValue,double displacementValue, int maxSpeedValue)
        {
            _name = nameValue;
            _dateReleased = dateValue;
            _portName = portValue;
            _displacement = displacementValue;
            _maxSpeed = Math.Max(10, maxSpeedValue);
        }
        public int CompareTo(object obj)
        {
            Ship cur = (Ship)obj;
            if (this.MaxSpeed > cur.MaxSpeed)
                return 1;
            else if (this.MaxSpeed < cur.MaxSpeed)
                return -1;
            return 0;
        }
        public abstract object Clone();
        public abstract object ShallowClone();
        public int Shells
        {
            get
            {
                if (this.GetType() == typeof(Corvette))
                    return (this as Corvette).NumOfShells;
                return 0;
            }
        }
        public int Guns
        {
            get
            {
                if (this.GetType() == typeof(Corvette))
                    return (this as Corvette).NumOfGuns;
                return 0;
            }
        }
        public virtual void Show()
        {
            Console.WriteLine(@"Название: {0}
Максимальная скорость (в узлах): {1}
Дата выпуска: {2}
Название порта: {3}
Водоизмещение (в тоннах): {4: 0.##}", _name, _maxSpeed, _dateReleased,_portName,_displacement);
        }
        private void InitRandomNames()
        {
            listShipNames = File.ReadAllLines(@"D:\проекты\Викентьевой\lab11\Названия.txt", Encoding.Default);
            listPortNames= File.ReadAllLines(@"D:\проекты\Викентьевой\lab11\Порты.txt", Encoding.Default);
        }
    }
}
