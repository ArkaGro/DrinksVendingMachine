using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace Drinks_Vending_Machine
{
    class IrishCoffee : Beverages
    {
        public IrishCoffee(string name, double price) : base (name, price)
        {

        }
        public override string Prepare(VendingMachine _manager)
        {
            string[] s = new string[3];
            s[0] = _manager.AddCoffee();
            s[1] = _manager.AddSugar();
            s[2] = _manager.AddMilk();

            string s2 = " ";
            foreach (var item in s)
            {
               s2 += item.ToString();
            }

            return $"{s2}";
        }
        public override string ToString()
        {
            return base.ToString() + Name + $"\nPrice Of The Drink:\n{Price}";
        }
    }
}
