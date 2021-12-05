using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drinks_Vending_Machine
{
    abstract class Beverages : IPrepare
    {
        private int[] _hotDrinks;
        private static int _counterDrinks;
        private string _name;
        private double _price;
        public string Name { get { return _name; } protected set { _name = value; } }
        public double Price { get { return _price; } protected set { _price = value; } }

        public Beverages(string name, double price)
        {
            this._name = name;
            this._price = price;
            _counterDrinks++;
        }
        public abstract string Prepare(VendingMachine manager);
       
        public override string ToString()
        {
            return "Name Of The Drink:\n";
        }
    }
}
