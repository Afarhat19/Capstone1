using Capstone.classes;
using MenuFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.CLI
{
    public class MainMenu : ConsoleMenu
    {
        public VendingMachine ourVendingMachine = new VendingMachine();

        /*******************************************************************************
         * Private data:
         * Usually, a menu has to hold a reference to some type of "business objects",
         * on which all of the actions requested by the user are performed. A common 
         * technique would be to declare those private fields here, and then pass them
         * in through the constructor of the menu.
         * ****************************************************************************/

        public MainMenu()
        {
            // Adds menu options to initialize program for initial display menu
            AddOption("Display Vending Machine items", DisplayItems, "1");
            AddOption("Purchase", ExitStatement, "2");
            AddOption("Exit", Close, "3");

            Configure(cfg =>
           {
               cfg.ItemForegroundColor = ConsoleColor.Yellow;
               cfg.MenuSelectionMode = MenuSelectionMode.KeyString; // KeyString: User types a key, Arrow: User selects with arrow
               cfg.KeyStringTextSeparator = ": ";
               cfg.Title = "Main Menu";
           });
        }
        
        // Displays our dictionary that holds vending machine items
        public MenuOptionResult DisplayItems()
        {
            foreach (KeyValuePair<string, VendingMachineItems> kvp in ourVendingMachine.TotalInventoryDictionary)
            {
                Console.WriteLine($"{kvp.Key} {kvp.Value.ProductType}     Remaining Quantity:   {kvp.Value.StockCount} \t {kvp.Value.Name} ${kvp.Value.Price} ");// This is where we left off!                   
            }
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        // Provides change amount to user and dispenses it
        public MenuOptionResult ExitStatement()
        {
            PurchaseMenu purchaseMenu = new PurchaseMenu();
            purchaseMenu.ourVendingMachine = this.ourVendingMachine;
            purchaseMenu.Show();
            Console.WriteLine($"Here's your Change Amount: ${ourVendingMachine.Balance}");

            ourVendingMachine.AuditLogGiveChangeMethod("GIVE CHANGE:", ourVendingMachine.Balance, 0);

            Change changeAmount = new Change(ourVendingMachine.Balance);
            changeAmount.PrintChangeOnScreen(changeAmount);
            Console.WriteLine("Thanks for shopping with us!");

            return MenuOptionResult.WaitAfterMenuSelection;

        }

    }
}

