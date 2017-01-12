using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;


namespace Lab01_WilliamFichtner
{
    class Program
    {
        struct Denominations
        {
            public string _name;
            public double _amount;

            public Denominations(string name, double amount)
            {
                _name = name;
                _amount = amount;
            }

        }
        

        static void Main(string[] args)
        {
            CDrawer canvas = new CDrawer();
            Denominations[] denomArray = new Denominations[9];
            int index = 0;
            double userInput = 0;
            double fifties = 0;            
            double twenties = 0;
            double tens = 0;
            double fives = 0;
            double toonies = 0;
            double loonies = 0;
            double quarters = 0;
            double dimes = 0;
            double nickels = 0;

            //Asks for user input and ensures the input is in proper format
            Console.WriteLine("Please enter a dollar amount:");
            while(double.TryParse(Console.ReadLine(), out userInput)== false)
            {
                Console.WriteLine("Please enter a valid dollar amount: ");
            }

            userInput = Math.Round(userInput / 0.05) * 0.05;


            Console.WriteLine("User entry interpreted and rounded to {0:C}", userInput);

            //Calculates amount of $50 bills and prepares the remainder for further calc
            fifties = CurrencyCalc(userInput, 50);
            Display(fifties, "Fifties");
            userInput = userInput - (fifties * 50);
            denomArray[index] = new Denominations("$50", fifties);
            index++;
            
            //Calculates the amount of $20 bills and prepares the remainder for further calc
            twenties = CurrencyCalc(userInput, 20);
            Display(twenties, "Twenties");
            userInput = userInput - (twenties * 20);
            denomArray[index] = new Denominations("$20", twenties);
            index++;

            //Calculates the amount of $10 bills and prepares the remainder for further calc
            tens = CurrencyCalc(userInput, 10);
            Display(tens, "Tens");
            userInput = userInput - (tens * 10);
            denomArray[index] = new Denominations("$10", tens);
            index++;

            //Calculates the amount of $5 bills and prepares the remainder for further calc
            fives = CurrencyCalc(userInput, 5);
            Display(fives, "Fives");
            userInput = userInput - (fives * 5);
            denomArray[index] = new Denominations("$5", fives);
            index++;

            //Calculates the amount of toonies and prepares the remainder for further calc
            toonies = CurrencyCalc(userInput, 2);
            Display(toonies, "Toonies");
            userInput = userInput - (toonies * 2);
            denomArray[index] = new Denominations("$2", toonies);
            index++;

            //Calculates the amount of loonies and prepares the remainder for further calc
            loonies = CurrencyCalc(userInput, 1);
            Display(loonies, "Loonies");
            userInput = userInput - loonies;
            denomArray[index] = new Denominations("$1", loonies);
            index++;

            //Calculates the amount of Quarters and prepares the remainder for further calc
            quarters = CurrencyCalc(userInput, 0.25);
            Display(quarters, "Quarters");
            userInput = userInput - (quarters * 0.25);
            denomArray[index] = new Denominations("$0.25", quarters);
            index++;

            //Calculates the amount of Dimes and prepares the remainder for further calc
            dimes = CurrencyCalc(userInput, 0.10);
            Display(dimes, "Dimes");
            userInput = userInput - (dimes * 0.10);
            denomArray[index] =  new Denominations("$0.10", dimes);
            index++;

            //Calculates the amount of Nickel and prepares the remainder for further calc
            nickels = CurrencyCalc(userInput, 0.05);
            Display(nickels, "Nickels");
            userInput = userInput - (nickels * 0.05);
            denomArray[index] = new Denominations("$0.05", nickels);
            index++;

            Draw(denomArray);

            Console.ReadLine();
        }

        private static double CurrencyCalc(double userInput, double currencyUnit)
        {
            double amount;
            double total;

            amount = userInput / currencyUnit;
            total = Math.Truncate(amount);

            return total;
        }
        private static void Display(double amount, string input)
        {
            Console.WriteLine("{0}: {1}", input, amount);
        }
        private static void Draw(Denominations[] arr)
        {
            foreach(Denominations n in arr)
            {
                
            }
        }
    }
}
