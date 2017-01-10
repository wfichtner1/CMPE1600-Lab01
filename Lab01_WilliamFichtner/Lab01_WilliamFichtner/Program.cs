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
        static void Main(string[] args)
        {
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

            Console.WriteLine("Please enter a dollar amount:");
            while(double.TryParse(Console.ReadLine(), out userInput)== false)
            {
                Console.WriteLine("Please enter a valid dollar amount: ");
            }
            Console.WriteLine("User entry of {0} interpreted and rounded to {1}", userInput, userInput);

            //Calculates amount of $50 bills and prepares the remainder for further calc
            fifties = CurrencyCalc(userInput, 50);
            Display(fifties, "Fifties");
            userInput = userInput - (fifties * 50);

            //Calculates the amount of $20 bills and prepares the remainder for further calc
            twenties = CurrencyCalc(userInput, 20);
            Display(twenties, "Twenties");
            userInput = userInput - (twenties * 20);

            //Calculates the amount of $10 bills and prepares the remainder for further calc
            tens = CurrencyCalc(userInput, 10);
            Display(tens, "Tens");
            userInput = userInput - (tens * 10);

            //Calculates the amount of $5 bills and prepares the remainder for further calc
            fives = CurrencyCalc(userInput, 5);
            Display(fives, "Fives");
            userInput = userInput - (fives * 5);

            //Calculates the amount of toonies and prepares the remainder for further calc
            toonies = CurrencyCalc(userInput, 2);
            Display(toonies, "Toonies");
            userInput = userInput - (toonies * 2);

            //Calculates the amount of loonies and prepares the remainder for further calc
            loonies = CurrencyCalc(userInput, 1);
            Display(loonies, "Loonies");
            userInput = userInput - loonies;

            //Calculates the amount of Quarters and prepares the remainder for further calc
            quarters = CurrencyCalc(userInput, 0.25);
            Display(quarters, "Quarters");
            userInput = userInput - (quarters * 0.25);

            //Calculates the amount of Dimes and prepares the remainder for further calc
            dimes = CurrencyCalc(userInput, 0.10);
            Display(dimes, "Dimes");
            userInput = userInput - (dimes * 0.10);

            //Calculates the amount of Nickel and prepares the remainder for further calc
            nickels = CurrencyCalc(userInput, 0.05);
            Display(nickels, "Nickels");
            userInput = userInput - (nickels * 0.05);

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
    }
}
