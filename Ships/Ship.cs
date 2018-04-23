using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Ships
{
    public abstract class Ship:IComparable,ICloneable
    {
        private static string[] listShipNames;
        protected static bool CheckDate(string date)
        {
            try
            {
                DateTime checkTime = DateTime.Parse(date);
                if (checkTime.Year < 1700 || checkTime > DateTime.Now)
                    return false;
            }
            catch
            {
                return false;
            }
            return true;

        }
        protected static Random rnd = new Random();
        protected int _maxSpeed;
        protected string _name;
        protected string _dateReleased;
        public int MaxSpeed
        {
            get { return _maxSpeed; }
            set { if (value < 1) throw new Exception("Значение скорости должно быть натуральным"); _maxSpeed = value; }
        }
        public string Name { set { _name = value; } get { return _name; } }
        public string DateReleased
        {
            get { return _dateReleased; }
            set
            {
                if (!CheckDate(value))
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
