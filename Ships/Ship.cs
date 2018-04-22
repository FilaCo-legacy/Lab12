using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Ships
{
    public abstract class Ship
    {
        public static string regDateReleasedValue = @"(?<=^|\s)((0{0,1}\d|1\d|2\d|3[01])(\.|\/)(0{0,1}[13578]|1[02])\3(1[7-9]\d\d|200\d))|((0{0,1}\d|1\d|2\d|30)(\.|\/)(0{0,1}[469]|11)\8(1[7-9]\d\d|200\d))|((0{0,1}\d|1\d|2[0-8])(\.|\/)(0{0,1}2)\13(1[7-9]\d\d))(?=$|\s)";
        private static string[] listShipNames;
        protected static bool CheckReg(string str, string pattern)
        {
            Regex reg = new Regex(pattern);
            return reg.IsMatch(str);
        }
        protected static Random rnd = new Random();
        protected int _maxSpeed;
        protected string _name;
        protected string _dateReleased;
        public int MaxSpeed
        {
            get { return _maxSpeed; }
            set { if (value < 0) throw new Exception("Скорость не может быть меньше 0"); _maxSpeed = value}
        }
        public string Name { set { _name = value; } get { return _name; } }
        public string DateReleased
        {
            get { return _dateReleased; }
            set
            {
                if (!CheckReg(value, regDateReleasedValue))
                    throw new Exception("Неверный формат даты");
                _dateReleased = value;
            }
        }
        public Ship()
        {
            if (listShipNames == null)
            InitRandomNames();
            _name = listShipNames[rnd.Next(listShipNames.Length)];
            _dateReleased = new DateTime(rnd.Next(1700, 2018), rnd.Next(1, 13), rnd.Next(1, 28)).ToShortDateString();
            _maxSpeed = rnd.Next(10, 32);
        }
        public Ship(string nameValue, string dateValue, int maxSpeedValue)
        {
            _name = nameValue;
            _dateReleased = dateValue;
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
        public virtual void Show()
        {
            Console.WriteLine(@"Название: {0}
Максимальная скорость (в узлах): {1}
Дата выпуска: {2}", _name, _maxSpeed, _dateReleased);
        }
        private void InitRandomNames()
        {
            listShipNames = File.ReadAllLines(@"Названия.txt", Encoding.Default);
        }
    }
}
