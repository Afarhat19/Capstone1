using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.classes
{
    public class Change
    {
        
        public int TwentyDollarBills { get; }
        public int TenDollarBills { get; }
        public int FiveDollarBills { get; }
        public int DollarBills { get; }
        public int Quarters { get; }
        public int Dimes { get; }
        public int Nickels { get; }
        public int Pennies { get; }


        public Change(decimal price)
        {         
            TwentyDollarBills = (int)(price / 20);
            price %= 20;

            TenDollarBills = (int)(price / 10);
            price %= 10;

            FiveDollarBills = (int)(price / 5);
            price %= 5;

            DollarBills = (int)(price / 1);
            price %= 1;

            Quarters = (int)(price / .25m);
            price %= .25m;

            Dimes = (int)(price / .10m);
            price %= .10m;

            Nickels = (int)(price / .05m);
            price %= .05m;

            Pennies = (int)(price / .01m);
        }

        public void PrintChangeOnScreen(Change changeAmount)
        {
            Console.WriteLine($"Twenty Dollar Bills: {changeAmount.TwentyDollarBills}");
            Console.WriteLine($"Ten Dollar Bills: {changeAmount.TenDollarBills}");
            Console.WriteLine($"Five Dollar Bills: {changeAmount.FiveDollarBills}");
            Console.WriteLine($"One Dollar Bills: {changeAmount.DollarBills}");
            Console.WriteLine($"Quarters: {changeAmount.Quarters}");
            Console.WriteLine($"Dimes: {changeAmount.Dimes}");
            Console.WriteLine($"Nickels: {changeAmount.Nickels}");
        }

    }
}
