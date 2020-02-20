using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace FirstBank
{
  class Program
  {
    static void SaveAccounts(List<Account> accounts)
    {
      var writer = new StreamWriter("Accounts.csv");
      var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
      csvWriter.WriteRecords(accounts);
      writer.Flush();
    }

    // static void DisplayAccounts(List<Account> accounts)
    // {
    //   var tracker = new AccountTracker();

    //   foreach (var account in tracker.Accounts)
    //   {
    //     Console.WriteLine($"{account.AccountName} has {account.AccountAmount}");
    //   }
    // }
    // two string method that exists on every object*******
    static void Main(string[] args)
    {

      // csv read and interpret
      var tracker = new AccountTracker();
      tracker.LoadData();

      // set variables equal to list(s)
      // Welcome the user
      Console.WriteLine("Welcome to the First Bank of Suncoast!");
      // Display totals for each account

      // Display last transaction

      // While (isRunning) setup
      var isRunning = true;
      while (isRunning)
      {
        tracker.DisplayAccounts();
        // What would you like to do?
        Console.WriteLine("Which account would you like to manage?");
        Console.WriteLine("(CHECKING), (SAVINGS), or (QUIT)?");
        var userInput = Console.ReadLine().ToLower();
        // user validation
        if (userInput != "checking" && userInput != "savings")
        {
          Console.WriteLine("That's not a correct choice. Please choose again from (CHECKING) or (SAVINGS)");
          userInput = Console.ReadLine().ToLower();
        }
        // if == CHECKING
        if (userInput == "checking")
        {
          tracker.DisplayChecking();
          Console.WriteLine("Would you like to (DEPOSIT), (WITHDRAW), or (TRANSFER) ?");
          userInput = Console.ReadLine().ToLower();
          if (userInput != "deposit" && userInput != "withdraw" && userInput != "savings")
          {
            Console.WriteLine("That's not a correct choice. Please choose again from (DEPOSIT), (WITHDRAW), or (TRANSFER)");
            userInput = Console.ReadLine().ToLower();
          }
          if (userInput == "deposit")
          {
            var account = "checking";
            Console.WriteLine("How much are you depositing?");
            var deposit = int.Parse(Console.ReadLine().ToLower());
            tracker.Deposit(account, deposit);
          }
          else if (userInput == "withdraw")
          {

          }
          else if (userInput == "transfer")
          {

          }
          // if (userInput == "return")
          // {

          // }


        }
        if (userInput == "savings")
        {

        }
        if (userInput == "quit")
        {

        }


        // if == SAVING


        // which account?
        // transfer from account a to account b and SaveAccounts();
        // extra credit: show previous three transactions?
      }
    }
  }
}
