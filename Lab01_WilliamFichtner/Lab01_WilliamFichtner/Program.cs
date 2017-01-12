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
            
            double[] denomArr = new double[9];
            int index = 0;
            double userInput = 0;
            string input = null;
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
            Console.Write("Please enter a dollar amount:");
            foreach(char c in Console.ReadLine())
            {
                if (char.IsDigit(c) || c == '.')
                {
                    input += c;
                }
            }
            if(double.TryParse(input, out userInput) == false)
            {
                Console.WriteLine("Please enter a valid dollar amount: ");
            }

            userInput = Math.Round(userInput / 0.05) * 0.05;


            Console.WriteLine("User entry interpreted and rounded to {0:C}", userInput);

            //Calculates amount of $50 bills and prepares the remainder for further calc
            fifties = CurrencyCalc(userInput, 50);
            Display(fifties, "Fifties");
            userInput = userInput - (fifties * 50);
            denomArr[0] = fifties;
            
            
            //Calculates the amount of $20 bills and prepares the remainder for further calc
            twenties = CurrencyCalc(userInput, 20);
            Display(twenties, "Twenties");
            userInput = userInput - (twenties * 20);
            denomArr[1] = twenties;
            

            //Calculates the amount of $10 bills and prepares the remainder for further calc
            tens = CurrencyCalc(userInput, 10);
            Display(tens, "Tens");
            userInput = userInput - (tens * 10);
            denomArr[2] = tens;
           

            //Calculates the amount of $5 bills and prepares the remainder for further calc
            fives = CurrencyCalc(userInput, 5);
            Display(fives, "Fives");
            userInput = userInput - (fives * 5);
            denomArr[3] = fives;

            //Calculates the amount of toonies and prepares the remainder for further calc
            toonies = CurrencyCalc(userInput, 2);
            Display(toonies, "Toonies");
            userInput = userInput - (toonies * 2);
            denomArr[4] = toonies;

            //Calculates the amount of loonies and prepares the remainder for further calc
            loonies = CurrencyCalc(userInput, 1);
            Display(loonies, "Loonies");
            userInput = userInput - loonies;
            denomArr[5] = loonies;
           

            //Calculates the amount of Quarters and prepares the remainder for further calc
            quarters = CurrencyCalc(userInput, 0.25);
            Display(quarters, "Quarters");
            userInput = userInput - (quarters * 0.25);
            denomArr[6] = quarters;

            //Calculates the amount of Dimes and prepares the remainder for further calc
            dimes = CurrencyCalc(userInput, 0.10);
            Display(dimes, "Dimes");
            userInput = userInput - (dimes * 0.10);
            denomArr[7] = dimes;

            //Calculates the amount of Nickel and prepares the remainder for further calc
            nickels = CurrencyCalc(userInput, 0.05);
            Display(nickels, "Nickels");
            userInput = userInput - (nickels * 0.05);
            denomArr[8] = nickels;

            Draw(denomArr);
            

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
        private static void Draw(double[] arr)
        {
            CDrawer canvas = new CDrawer();
            
            if(arr[0] > 0)
            {
                canvas.AddRectangle(50, 30, 300, 130, Color.Red);
                canvas.AddText("50 x " + arr[0].ToString(), 20, 50, 30, 300, 130, Color.White);
            }
            if (arr[1] > 0)
            {
                canvas.AddRectangle(50, 170, 300, 130, Color.Green);
                canvas.AddText("20 x " + arr[1].ToString(), 20, 50, 170, 300, 130, Color.White);
            }
            if (arr[2] > 0)
            {
                canvas.AddRectangle(50, 310, 300, 130, Color.Purple);
                canvas.AddText("10 x " + arr[2].ToString(), 20, 50, 310, 300, 130, Color.White);
            }
            if (arr[3] > 0)
            {
                canvas.AddRectangle(50, 450, 300, 130, Color.LightBlue);
                canvas.AddText("5 x " + arr[3].ToString(), 20, 50, 450, 300, 130, Color.White);
            }
            if (arr[4] > 0)
            {
                canvas.AddEllipse(500, 30, 100, 100, Color.Silver);
                canvas.AddCenteredEllipse(550, 80, 80, 80, Color.Gold);
            }

        }
    }
}
