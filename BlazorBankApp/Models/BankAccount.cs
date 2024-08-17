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
   //Property to store the account balance (protected to prevent direct modification)
   public double Balance { get; protected set; }
   //Method to retrieve the current balance
   public double GetBalance() => Balance;
   //Method to deposit funds into an account
   public void Deposit(double amount, BankAccount toAccount)
   {
    //Check if the deposit amount is positive
    if (amount > 0)
    {
     //add the deposit amount to the account balance
     toAccount.Balance += amount;
    }
   }
    //Method to withdraw funds from an account
   public bool Withdraw(double amount, BankAccount fromAccount)
   {
    //Check if the withdraw amount is positive and the account has sufficient funds
    if (amount > 0 && fromAccount.Balance >= amount)
    {
     //Subtract the withdrawal amount from the account balance
     fromAccount.Balance -= amount;
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
   
 //Class representing a savings account (inherits from BankAccount)
 class SavingsAccount : BankAccount
 {
 }
 //Class representing an everyday account
  class EverydayAccount : BankAccount
 {
 } 
