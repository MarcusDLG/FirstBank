using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using FirstBank;

namespace FirstBank
{
  public class AccountTracker
  {
    public List<Account> Accounts { get; set; } = new List<Account>();

    // method for Display accounts
    public void DisplayAccounts()
    {
      foreach (var account in Accounts)
      {
        Console.WriteLine($"Your {account.AccountName} account has {account.AccountAmount}");
      }
    }
    public void DisplayChecking()
    {
      var checking = Accounts.First(accounts => accounts.AccountName == "checking").AccountAmount;
      Console.WriteLine($"Your checking account has {checking} dollars.");
    }

    public void Deposit(string AccountName, int AccountAmount)
    {
      var checking = Accounts.First(accounts => accounts.AccountName == AccountName);
    }

    public void LoadData()
    {
      var reader = new StreamReader("Accounts.csv");
      var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
      Accounts = csvReader.GetRecords<Account>().ToList();
    }



    // Method for deposit
    // Method for withdrawal
    // method for transfer
  }
}

