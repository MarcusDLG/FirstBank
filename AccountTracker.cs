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
    public void LoadData()
    {
      var reader = new StreamReader("Accounts.csv");
      var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
      Accounts = csvReader.GetRecords<Account>().ToList();
    }

    public void SaveData()
    {
      var writer = new StreamWriter("Accounts.csv");
      var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
      csvWriter.WriteRecords<Account>(Accounts);
      writer.Flush();
    }
    public void DisplayAccounts()
    {
      foreach (var account in Accounts)
      {
        Console.WriteLine($"Your {account.AccountName} account has ${account.AccountAmount}");
      }
    }
    public void DisplayAccount(string AccountName)
    {
      var checking = Accounts.First(accounts => accounts.AccountName == AccountName).AccountAmount;
      Console.WriteLine($"Your {AccountName} account has ${checking} dollars.");
    }

    public void Deposit(string AccountName, int AccountAmount)
    {
      var account = Accounts.First(accounts => accounts.AccountName == AccountName).AccountAmount;
      account += AccountAmount;
      Accounts.First(account => account.AccountName == AccountName).AccountAmount = account;
      SaveData();
      Console.Clear();

    }


    internal void Withdrawl(string AccountName, int AccountAmount)
    {
      var account = Accounts.First(accounts => accounts.AccountName == AccountName).AccountAmount;
      account -= AccountAmount;
      Accounts.First(account => account.AccountName == AccountName).AccountAmount = account;
      SaveData();
      Console.Clear();
    }

    internal void Transfer(string AccountName, int AccountAmount)
    {
      if (AccountName == "checking")
      {

        var account1 = Accounts.First(accounts => accounts.AccountName == AccountName).AccountAmount;
        account1 -= AccountAmount;
        Accounts.First(account => account.AccountName == AccountName).AccountAmount = account1;
        var account2 = Accounts.First(accounts => accounts.AccountName == "savings").AccountAmount;
        account2 += AccountAmount;
        Accounts.First(account => account.AccountName == "savings").AccountAmount = account2;
        SaveData();
        Console.Clear();

      }
      else if (AccountName == "savings")
      {
        var account1 = Accounts.First(accounts => accounts.AccountName == AccountName).AccountAmount;
        account1 -= AccountAmount;
        Accounts.First(account => account.AccountName == AccountName).AccountAmount = account1;
        var account2 = Accounts.First(accounts => accounts.AccountName == "checking").AccountAmount;
        account2 += AccountAmount;
        Accounts.First(account => account.AccountName == "checking").AccountAmount = account2;
        SaveData();
        Console.Clear();

      }
    }



    // Method for deposit
    // Method for withdrawal
    // method for transfer
  }
}

