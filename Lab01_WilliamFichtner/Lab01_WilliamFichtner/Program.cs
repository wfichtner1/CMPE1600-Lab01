using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

//Program:      Lab01_WilliamFichtner
//Description:  Takes a monetary value given by  user and
//              sorts it into different denominations
//Lab:          1
//Date:         January 11.2017
//Author:       William Fichtner
//Class:        CMPE 1600
//Instructor:   JD Silver

namespace Lab01_WilliamFichtner
{
    class Program
    {

        static void Main(string[] args)
        {            
            double[] denomArr = new double[9];      //An array that holds the amount of each denomination for the GDI drawer
            double userInput = 0;                   //User input that has been converted to a double
            bool proceed = true;                    //Check for input loop
            string total;                           //Used to pass the user value as a string to the draw method 
            string input = null;                    //Initial input given by user
            double fifties = 0;                     //Holds the amount of $50 bills
            double twenties = 0;                    //Holds the amount of $20 bills
            double tens = 0;                        //Holds the amount of $10 bills
            double fives = 0;                       //Holds the amount of $5 bills
            double toonies = 0;                     //Holds the amount of toonies
            double loonies = 0;                     //Holds the amount of loonies
            double quarters = 0;                    //Holds the amount of quarters
            double dimes = 0;                       //Holds the amount of dimes
            double nickels = 0;                     //Holds the amount of nickels

            //Asks for user input and ensures the input is in proper format
            do
            {
                Console.Write("Please enter a dollar amount: ");
                proceed = true;

                //Checks each character in the user input and ensures it is a digit, so symbols and letters are disallowed
                foreach (char c in Console.ReadLine())
                {
                    if (char.IsDigit(c) || c == '.')
                    {
                        input += c;
                    }
                }

                total = input;

                //converts input to double, and asks for new input if unable
                if (double.TryParse(input, out userInput) == false)
                {
                    Console.WriteLine("Please enter a valid dollar amount: ");
                    proceed = false;
                }
            } while (proceed == false);

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

            Draw(denomArr, total);
            

            Console.ReadLine();
        }
        //Calculates the amount of each denomination in the input given by user
        private static double CurrencyCalc(double userInput, double currencyUnit)
        {
            double amount;
            double total;

            amount = userInput / currencyUnit;
            total = Math.Truncate(amount);

            return total;
        }
        //Writes the amount of each denomination in the console
        private static void Display(double amount, string input)
        {
            Console.WriteLine("{0}: {1}", input, amount);
        }
        //Draws the denominations on the GDI canmvas
        private static void Draw(double[] arr, string total)
        {
            CDrawer canvas = new CDrawer();

            canvas.AddText("$" + total, 20, 350, 0, 150, 40, Color.Gold); 
            
            //This series checks if there is an amount of each denomination
            //and then chooses to draw it or not
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
                canvas.AddText("2 X " + arr[4].ToString(), 20, 510, 40, 80, 80, Color.White);
            }
            if (arr[5] > 0)
            {
                canvas.AddEllipse(505, 140, 90, 90, Color.Gold);
                canvas.AddText("1 X " + arr[5].ToString(), 20, 510, 145, 80, 80, Color.White);
            }
            if (arr[6] > 0)
            {
                canvas.AddEllipse(505, 250, 80, 80, Color.Silver);
                canvas.AddText("0.25 X " + arr[6].ToString(), 15, 500, 245, 90, 90, Color.White);
            }
            if (arr[7] > 0)
            {
                canvas.AddEllipse(515, 360, 60, 60, Color.Silver);
                canvas.AddText("0.10 X " + arr[7].ToString(), 15, 500, 345, 90, 90, Color.White);
            }
            if (arr[8] > 0)
            {
                canvas.AddEllipse(505, 470, 70, 70, Color.Silver);
                canvas.AddText("0.05 X " + arr[8].ToString(), 15, 500, 460, 90, 90, Color.White);
            }

        }
    }
}
