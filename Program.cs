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

    // static void SaveAccounts(List<Account> accounts)
    // {
    //   var writer = new StreamWriter("Accounts.csv");
    //   var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
    //   csvWriter.WriteRecords(accounts);
    //   writer.Flush();
    // }

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

      // set variables equal to list(s)
      // Welcome the user
      Console.WriteLine("Welcome to the First Bank of Suncoast!");
      // Display totals for each account

      // Display last transaction

      // While (isRunning) setup
      var isRunning = true;
      while (isRunning)
      {

        var tracker = new AccountTracker();
        var transactionTracker = new TransactionTracker();
        tracker.LoadData();
        tracker.DisplayAccounts();
        transactionTracker.LoadData();
        transactionTracker.DisplayLast();
        // transactionTracker.DisplayLast();
        // What would you like to do?
        Console.WriteLine("Which account would you like to manage?");
        Console.WriteLine("(CHECKING), (SAVINGS), or (QUIT)?");
        var userInput = Console.ReadLine().ToLower();
        // user validation
        if (userInput != "checking" && userInput != "savings" && userInput != "quit")
        {
          Console.WriteLine("That's not a correct choice. Please choose again from (CHECKING) or (SAVINGS)");
          userInput = Console.ReadLine().ToLower();
        }
        // if == CHECKING
        else if (userInput == "checking")
        {
          tracker.DisplayAccount("checking");
          Console.WriteLine("Would you like to (DEPOSIT), (WITHDRAW), or (TRANSFER) ?");
          userInput = Console.ReadLine().ToLower();
          if (userInput != "deposit" && userInput != "withdraw" && userInput != "transfer")
          {
            Console.WriteLine("That's not a correct choice. Please choose again from (DEPOSIT), (WITHDRAW), or (TRANSFER)");
            userInput = Console.ReadLine().ToLower();
          }
          if (userInput == "deposit")
          {
            // var account = "checking";
            Console.WriteLine("How much are you depositing?");
            var deposit = double.Parse(Console.ReadLine().ToLower());
            tracker.Deposit("checking", deposit);
            transactionTracker.AddTransaction("deposit", "checking", deposit);
            var transactionType = "deposit";
            transactionTracker.AddTransaction(transactionType, "checking", deposit);

          }
          else if (userInput == "withdraw")
          {
            Console.WriteLine("How much are you withdrawing?");
            var deposit = double.Parse(Console.ReadLine().ToLower());
            tracker.Withdrawl("checking", deposit);
            var transactionType = "withdrawal";
            transactionTracker.AddTransaction(transactionType, "checking", deposit);
            // transactionTracker.AddTransaction("withdrawal", "checking", deposit, DateTime.Now);


          }
          else if (userInput == "transfer")
          {
            Console.WriteLine("How much are you transfering?");
            var transfer = double.Parse(Console.ReadLine().ToLower());
            tracker.Transfer("checking", transfer);
            var transactionType = "transfer";
            transactionTracker.AddTransaction(transactionType, "savings", transfer);

          }
        }
        else if (userInput == "savings")
        {
          tracker.DisplayAccount("savings");
          Console.WriteLine("Would you like to (DEPOSIT), (WITHDRAW), or (TRANSFER) ?");
          userInput = Console.ReadLine().ToLower();
          if (userInput != "deposit" && userInput != "withdraw" && userInput != "transfer")
          {
            Console.WriteLine("That's not a correct choice. Please choose again from (DEPOSIT), (WITHDRAW), or (TRANSFER)");
            userInput = Console.ReadLine().ToLower();
          }
          if (userInput == "deposit")
          {
            // var account = "checking";
            Console.WriteLine("How much are you depositing?");
            var deposit = double.Parse(Console.ReadLine().ToLower());
            tracker.Deposit("savings", deposit);
            var transactionType = "deposit";
            transactionTracker.AddTransaction(transactionType, "savings", deposit);

          }
          if (userInput == "withdraw")
          {
            Console.WriteLine("How much are you withdrawing?");
            var deposit = double.Parse(Console.ReadLine().ToLower());
            tracker.Withdrawl("savings", deposit);
            var transactionType = "withdrawal";
            transactionTracker.AddTransaction(transactionType, "savings", deposit);
          }
          if (userInput == "transfer")
          {
            Console.WriteLine("How much are you transfering?");
            var transfer = double.Parse(Console.ReadLine().ToLower());
            tracker.Transfer("savings", transfer);
            var transactionType = "transfer";
            transactionTracker.AddTransaction(transactionType, "savings", transfer);

          }
        }
        else if (userInput == "quit")
        {
          isRunning = false;
          Console.WriteLine("Goodbye User!");
        }


        // if == SAVING


        // which account?
        // transfer from account a to account b and SaveAccounts();
        // extra credit: show previous three transactions?
      }
    }
  }
}
