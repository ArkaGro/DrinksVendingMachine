using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.UI.Xaml.Media.Imaging;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Threading;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Drinks_Vending_Machine
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Beverages _beverages;
        List<BitmapImage> _images;
        VendingMachine _vendingMachine;
        Latte _latte;
        IrishCoffee _irishCoffee;
        Cappuchino _cappuchino;
        private bool _IsCappucino = false;
        private bool _IsIrishCoffee = false;
        private bool _IsLatte = false;
        private bool _IsCupChoosed = false;
        private bool _IsCoffeeChoosed = false;
        private bool _IsPaid = false;
        private bool _IsCoinInserted = false;
        private string s = "Inserted Coins:\n";

        public MainPage()
        {
            this.InitializeComponent();
            _images = new List<BitmapImage>();

            _vendingMachine = new VendingMachine(_images);
            _vendingMachine.AddBeverage(new Latte("Latte", 16.40));
            _vendingMachine.AddBeverage(new Cappuchino("Cappucino", 14.20));
            _vendingMachine.AddBeverage(new IrishCoffee("Irish Coffee", 18.60));

        }
        private void BT_Click_Latte(object sender, RoutedEventArgs e) // Latte Coffee Button
        {
            _latte = new Latte("Latte", 16.40);
            showChoice.Text = _latte.ToString();  // Shows Message on the screen

            _IsLatte = true; // Brings TRUE to Condition _IsLatte
            _IsCoffeeChoosed = true; // Brings TRUE to Condition _IsCoffeeChoosed

            _IsCappucino = false; // Nullify Conditon _IsCappucino
            _IsIrishCoffee = false; // Nullify Conditon _IsIrishCoffee
        }
        private void BT_Click_Cappuchino(object sender, RoutedEventArgs e) // Cappuchino Coffee Button
        {
            _cappuchino = new Cappuchino("Cappucino", 14.20);
            showChoice.Text = _cappuchino.ToString();  // Shows Message on the screen

            _IsCappucino = true; // Brings TRUE to Condition _IsCappucino
            _IsCoffeeChoosed = true; // Brings TRUE to Condition _IsCoffeeChoosed

            _IsLatte = false; // Nullify Conditon _IsLatte
            _IsIrishCoffee = false; // Nullify Conditon _IsIrishCoffee
        }
        private void BT_Click_IrishCoffee(object sender, RoutedEventArgs e) // Irish Coffee Button
        {
            _irishCoffee = new IrishCoffee("Irish Coffee", 18.60);
            showChoice.Text = _irishCoffee.ToString();  // Shows Message on the screen

            _IsIrishCoffee = true; // Brings TRUE to Condition _IsIrishCoffee
            _IsCoffeeChoosed = true; // Brings TRUE to Condition _IsCoffeeChoosed

            _IsLatte = false; // Nullify Conditon _IsLatte
            _IsCappucino = false; // Nullify Conditon _IsCappucino
        }
        private void BT_Click_Accept(object sender, RoutedEventArgs e) // Accept Button
        {
            string cup = "Choose A Cup!";
            string coffee = "Choose Coffee!";
            string pay = "Don't Forget To Pay!";
            if (_IsCupChoosed == true) // Checks if choosed cup
            {
                if (_IsCoffeeChoosed == true) // checks if coffee choosed
                {
                    if (_IsPaid == true) // checks if paiment performed
                    {
                        if (_IsCappucino == true)  // if choosed cappuchino
                        {
                            showChoice.Text = _cappuchino.Prepare(_vendingMachine);
                        }
                        else if (_IsIrishCoffee == true)  // if choosed irish coffee
                        {
                            showChoice.Text = _irishCoffee.Prepare(_vendingMachine);
                        }
                        else if (_IsLatte == true)  // if choosed latte
                        {
                            showChoice.Text = _latte.Prepare(_vendingMachine);
                        }
                        _IsPaid = false; // Nullify Conditon _IsPaid
                        _IsCoinInserted = false; // Nullify Conditon _IsCoinInserted
                        _IsCoffeeChoosed = false; // Nullify Conditon _IsCoffeeChoosed
                        _IsCupChoosed = false; // Nullify Conditon _IsCupChoosed
                    }
                    else
                        showChoice.Text = pay; // Shows Message on the screen
                }
                else
                    showChoice.Text = coffee; // Shows Message on the screen
            }
            else
                showChoice.Text = cup; // Shows Message on the screen
        }
        private void Big_Cups_Click(object sender, RoutedEventArgs e) // Big Cups Button
        {
            _IsCupChoosed = true;
            showChoice.Text = _vendingMachine.ChoosedABigCup();
        }
        private void Little_Cups_Click(object sender, RoutedEventArgs e) // Little Cups Button
        { 
            _IsCupChoosed = true;
            showChoice.Text = _vendingMachine.ChoosedALittleCup();
        }
        private void PayMoney_Click(object sender, RoutedEventArgs e) // Pay Money Button
        {
            if (_IsCoffeeChoosed == true && _IsCupChoosed == true && _IsCoinInserted == true) // Checks if All Conditions are Performed
            {
                if (_IsLatte == true) // Latte Coffee choosed
                {
                    _IsPaid = (_vendingMachine.PriceChecker(_vendingMachine.Money, _latte.Price)); // Checks if inserted money equals to price
                    if (_vendingMachine.Money > _latte.Price)  // Checks if inserted money more than price
                    {
                        showChoice.Text = (_vendingMachine.SpareMoney().ToString()) + (_vendingMachine.SpareMoney(_latte.Price, _vendingMachine.Money)).ToString();
                        _IsPaid = true;
                    }
                    else if (_vendingMachine.Money < _latte.Price) // Checks if inserted money less than price
                    {
                        showChoice.Text = (_vendingMachine.NotEnoughMoney().ToString()) + (_vendingMachine.NotEnoughMoney(_latte.Price, _vendingMachine.Money)).ToString();
                    }
                }
               else if (_IsCappucino == true) // Cappuchino Coffee choosed
                {
                    _IsPaid = _vendingMachine.PriceChecker(_vendingMachine.Money, _cappuchino.Price); // Checks if inserted money equals to price
                    if (_vendingMachine.Money > _cappuchino.Price) // Checks if inserted money more than price
                    {
                        showChoice.Text = (_vendingMachine.SpareMoney().ToString()) + (_vendingMachine.SpareMoney(_cappuchino.Price, _vendingMachine.Money)).ToString();
                        _IsPaid = true;
                    }
                    else if (_vendingMachine.Money < _cappuchino.Price) // Checks if inserted money less than price
                    {
                        showChoice.Text = (_vendingMachine.NotEnoughMoney().ToString()) + (_vendingMachine.NotEnoughMoney(_cappuchino.Price, _vendingMachine.Money)).ToString();
                    }
                }
               else if (_IsIrishCoffee == true) // Irish Coffee choosed
                {
                    _IsPaid = _vendingMachine.PriceChecker(_vendingMachine.Money, _irishCoffee.Price); // Checks if inserted money equals to price
                    if (_vendingMachine.Money > _irishCoffee.Price) // Checks if inserted money more than price
                    {
                        showChoice.Text = (_vendingMachine.SpareMoney().ToString()) + (_vendingMachine.SpareMoney(_irishCoffee.Price, _vendingMachine.Money)).ToString();
                        _IsPaid = true;
                    }
                    else if (_vendingMachine.Money < _irishCoffee.Price) // Checks if inserted money less than price
                    {
                        showChoice.Text = (_vendingMachine.NotEnoughMoney().ToString()) + (_vendingMachine.NotEnoughMoney(_irishCoffee.Price, _vendingMachine.Money)).ToString();
                    }
                }
            }
            else
                showChoice.Text = "Forgot Something!";
        }
        private void Ten_Shekels_Click(object sender, RoutedEventArgs e) // Ten Shekels Button
        {
            double coin = 10;
            showChoice.Text = s + (_vendingMachine.InsertedCoins(coin)).ToString();
            _IsCoinInserted = true;
        }
        private void Five_Shekels_Click(object sender, RoutedEventArgs e) // Five Shekels Button
        {
            double coin = 5;
            showChoice.Text = s + (_vendingMachine.InsertedCoins(coin)).ToString();
            _IsCoinInserted = true;
        }
        private void One_Shekel_Click(object sender, RoutedEventArgs e) // One Shekel Button
        {
            double coin = 1;
            showChoice.Text = s + (_vendingMachine.InsertedCoins(coin)).ToString();
            _IsCoinInserted = true;
        }
        private void Fifty_Agorot_Click(object sender, RoutedEventArgs e) // Fifty Agorot Button
        {
            double coin = 0.50;
            showChoice.Text = s + (_vendingMachine.InsertedCoins(coin)).ToString();
            _IsCoinInserted = true;
        }
        private void BT_Click_Take(object sender, RoutedEventArgs e)  // Vending Machine Exit Button
        {
            Environment.Exit(0);
        }
    }
}
