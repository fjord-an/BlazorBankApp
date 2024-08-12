using BlazorBankApp.Models;

namespace BlazorBankApp.Services;
// This service class manages bank accounts for the application.
public class BankAccountService
{
    //Property to store the everyday bank account.
    public BankAccount EverydayAccount { get; set; }
    //Property to store the savings bank account.
    public BankAccount SavingsAccount { get; set; }
    //Constructor to initialise the bank accounts.
    public BankAccountService(BankAccount everydayAccount, BankAccount savingsAccount)
    {   //Set the everyday account.
        EverydayAccount = everydayAccount;
        //Set the savings account.
        SavingsAccount = savingsAccount;
    }
}
