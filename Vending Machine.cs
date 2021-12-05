using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Windows.UI.Xaml;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace Drinks_Vending_Machine
{
    class VendingMachine
    {
        List<BitmapImage> _images;
        private int _numOfDrinks;
        private int _sugar = 25;
        private int _bigCups = 25;
        private int _littleCups = 25;
        private int _coffeBeans = 25;
        private int _milk = 25;
        private double _money;
        private Beverages[] _beverages;
        const int _drinksAmount = 20;
        public double Money { get { return _money; } protected set { _money = value; } }
        public VendingMachine(List<BitmapImage> images)
        {
            _beverages = new Beverages[_drinksAmount];
            _images = images;
            _numOfDrinks++;
        }
        public bool AddBeverage(Beverages beverages) // Add Function AddBeverage()
        {                                            // Adds Beverages to Array Beverages[]
            if (beverages == null)
                return false;
            if (_numOfDrinks > _beverages.Length)
                return false;
            _beverages[_numOfDrinks++] = beverages;
            return true;
        }
        public bool RemoveBeverage(Beverages beverages) // Remove Function RemoveBeverage()
        {                                             // Removes Beverages from Array Beverages[]
            if (beverages == null)
                return false;
            _beverages[_numOfDrinks--] = beverages;
            return true;
        }
        public bool PriceChecker(double money, double price) // Price Checker Function PriceChecker()
        {
            money = Math.Round(money, 2); // Try to round money to 2 signs after point

            if (money.CompareTo(price) == 0)
            {
                return true;
            }
            else 
            return false;
        }
        public double SpareMoney(double money, double price) // Spare Money Function SpareMoney() 
        {                                                    // Count how many money to bring
            double result = 0;
            result = price - money;
            Math.Round(result, 2);
            return result;
        }
        public double NotEnoughMoney(double money, double price) // NotEnoughMoney() Function 
        {                                                        // Count how many money customer should to add
            double result = 0;
            result = money - price;
            Math.Round(result, 2);
            return result;
        }
        public double InsertedCoins(double a)  // InsertedCoins() Function
        {                                      // Count Amount of inserted coins (Money)
            Math.Round(a, 2);
            Money = Money + a;
            return Money;
        }
        public string SpareMoney()  // string StareMoney() Function
        {                           // Send to the screen message 
            string spare = "Please, take your spare money:\n";
            return spare;
        }
        public string NotEnoughMoney() // string NotEnoughMoney() Function
        {                           // Send to the screen message 
            string notEnought = "Not enough money, add:\n";
            return notEnought;
        }
        public string AddSugar() // AddSugar() Function
        {
            if (_sugar <= 0)
                throw new ArgumentException("There is no sugar!");
            else
                _sugar--;  // takes away sugar
            return "Adding Sugar!\n";
        }
        public string AddCoffee() // AddCoffee() Function
        {
            if (_coffeBeans <= 0)
                throw new ArgumentException("There is no Coffee Beans!");
            else
                _coffeBeans--; // takes away coffee beans
            return "Adding Coffee!\n";
        }
        public string AddMilk() // AddMilk() Function
        {
            if (_milk <= 0)
                throw new ArgumentException("There is no milk!");
            else
                _milk--; // takes away milk
            return "Adding Milk!\n";
        }
        public string ChoosedABigCup() // ChoosedABigCup() Function
        {
                if (_bigCups <= 0)
                    throw new ArgumentException("There is no Big Cups!");
                else
                    _bigCups--; // takes away Bug Cups
            return "Big Cup Choosed!\n";
        }
        public string ChoosedALittleCup() // ChoosedALittleCup() Function
        {
            if (_littleCups <= 0)
                throw new ArgumentException("There is no Little Cups!");
            else
                _littleCups--; // takes away Little Cups
            return "Little Cup Choosed!\n";
        }
        public override string ToString()
        {
            return "Here You Can See Your Choice:\n";
        }
    }
}
