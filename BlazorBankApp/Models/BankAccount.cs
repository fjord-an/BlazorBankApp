using BlazorBankApp.Models;

 namespace BlazorBankApp.Models 
 {
  public abstract class BankAccount
  {
   //TODO add comments
   public string AccountNumber { get; set; }
   public string AccountHolder { get; set; }
   public double Balance { get; protected set; }

   public double GetBalance() => Balance;

   public void Deposit(double amount, BankAccount toAccount)
   {
    if (amount > 0)
    {
     toAccount.Balance += amount;
    }
   }

   public bool Withdraw(double amount, BankAccount fromAccount)
   {
    if (amount > 0 && fromAccount.Balance >= amount)
    {
     fromAccount.Balance -= amount;
     return true;
    }
    return false;
   }

   public bool Transfer(double amount, BankAccount toAccount, BankAccount fromAccount)
   {
    // toAccount.Deposit(amount);
    if (Withdraw(amount, fromAccount))
    {
     toAccount.Deposit(amount, toAccount);
     return true;
    }
    return false;
   }
  }
 }
 
 class SavingsAccount : BankAccount
 {
  //TODO should this be moved to another file?
 }
 class EverydayAccount : BankAccount
 {
  //TODO should this be moved to another file?
 }