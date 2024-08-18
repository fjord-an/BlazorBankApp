//Import the necessary namespace for the application's models
using BlazorBankApp.Models;

//Define a namespace for the application's models
namespace BlazorBankApp.Models
{
 //Define an abstract class for a bank account
 public abstract class BankAccount
 {
  //Property to store the account number
  public string AccountNumber { get; set; }

  //Property to store the account holder's name
  public string AccountHolder { get; set; }
  
  // Property to store the account holder's information (from the UserInfo object)
  public UserInfo AccountHolderInfo { get; set; }
  public double Balance { get; private set; }
  
  public BankAccount(string accountNumber, string accountHolder, double initialBalance = 0)
  {
   // Set the account number, account holder, and initial balance
   AccountNumber = accountNumber;
   AccountHolder = accountHolder;
   Balance = initialBalance;
  }

  //Method to deposit funds into an account
  public void Deposit(double amount, BankAccount toAccount)
  {
   //Check if the deposit amount is positive
   if (amount > 0)
   {
    //add the deposit amount to the account balance
    Balance += amount;
   }
  }

  //Method to withdraw funds from an account
  public bool Withdraw(double amount, BankAccount fromAccount)
  {
   //Check if the withdraw amount is positive and the account has sufficient funds
   if (amount > 0 && Balance >= amount)
   {
    //Subtract the withdrawal amount from the account balance
    Balance -= amount;
    return true; //Return true to indicate a successful withdrawal is successful
   }

   return false; //Return false to indicate as unsuccessful withdrawal
  }

  //Method to transfer funds between accounts
  public bool Transfer(double amount, BankAccount toAccount, BankAccount fromAccount)
  {
   //Check if the withdrawal from the source account is successful
   if (Withdraw(amount, fromAccount))
   {
    //Deposit the transferred amount into the target account
    toAccount.Deposit(amount, toAccount);
    return true; //Return true to indicate a successful transfer
   }

   return false; //Return false to indicate an unsuccessful transfer
   {
   }
  }
 }

 // The following classes are derived from the BankAccount class and exhibit polymorphism in the Bank.razor component.
 // In this component, the transfer methods utilize these different types of BankAccount objects to add and subtract
 // funds from the respective accounts. They can also hold their own values for the properties of the BankAccount class.
 // (such as Balance)
 class SavingsAccount : BankAccount
 {
  // Override the base class' constructor to initialise the instantiated SavingsAccount object with the same data format
  // as the BankAccount object. The SavingsAccount class inherits the properties and methods of the BankAccount class,
  // and is identical to the BankAccount class, so it should inherit the same data format.
  public SavingsAccount(string accountNumber, string accountHolder, double initialBalance = 0)
   : base(accountNumber, accountHolder, initialBalance) { } 
 }

 // Class representing an everyday account
 class EverydayAccount : BankAccount
 {
  // like the SavingsAccount class, the EverydayAccount class inherits the properties and methods of the BankAccount class.
  // These derived classes are used to represent different types of bank accounts, such as savings accounts and everyday accounts.
  public EverydayAccount(string accountNumber, string accountHolder, double initialBalance = 0)
   : base(accountNumber, accountHolder, initialBalance) { }
 }
}
