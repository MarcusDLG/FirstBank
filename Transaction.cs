using System;

namespace FirstBank
{
  public class Transaction
  {
    // public string UserName {get; set;}
    public string TransactionAccount { get; set; }
    public string TransactionType { get; set; }
    public double TransactionAmount { get; set; }

    public DateTime TransactionTime { get; set; }
  }
}