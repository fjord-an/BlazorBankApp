using BlazorBankApp.Models;

namespace BlazorBankApp.Services;

public class BankAccountService
{
    //TODO add comments
    public BankAccount EverydayAccount { get; set; }
    public BankAccount SavingsAccount { get; set; }

    public BankAccountService(BankAccount everydayAccount, BankAccount savingsAccount)
    {
        EverydayAccount = everydayAccount;
        SavingsAccount = savingsAccount;
    }
}