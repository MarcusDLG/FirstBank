using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;




// issues: transaction tracker overwriting all with current date time not time added
// won't display last transaction


namespace FirstBank
{
  public class TransactionTracker
  {
    public List<Transaction> Transactions { get; set; } = new List<Transaction>();

    public void LoadData()
    {
      var reader = new StreamReader("Transactions.csv");
      var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
      Transactions = csvReader.GetRecords<Transaction>().ToList();
    }



    public void SaveData()
    {
      var writer = new StreamWriter("Transactions.csv");
      var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
      csvWriter.WriteRecords<Transaction>(Transactions);
      writer.Flush();
    }

    public void AddTransaction(string TransactionType, string TransactionAccount, double TransactionAmount)
    {
      var transactionAdd = new Transaction
      {
        TransactionType = TransactionType,
        TransactionAccount = TransactionAccount,
        TransactionAmount = TransactionAmount,
        TransactionTime = DateTime.Now,
      };

      Transactions.Add(transactionAdd);
      SaveData();
    }

    public void DisplayLast()
    {
      var lastTransaction = (Transactions.OrderByDescending(displayLast => displayLast.TransactionTime).Take(1));
      foreach (var transaction in lastTransaction)
      {
        Console.WriteLine($"Your last transaction was a {transaction.TransactionType} for ${transaction.TransactionAmount} from (to if transfer) {transaction.TransactionAccount} ");
      }
    }

    public void DisplayAll()
    {
      var allTransactions = (Transactions.OrderByDescending(displayLast => displayLast.TransactionTime));
      foreach (var transaction in allTransactions)
      {
        Console.WriteLine($"Your last transaction was a {transaction.TransactionType} for ${transaction.TransactionAmount} from (to if transfer) {transaction.TransactionAccount} ");
      }
    }
  }
}