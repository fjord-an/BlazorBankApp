using BlazorBankApp.Models;

namespace BlazorBankApp.Services;

public class BankAccountService
{
    public BankAccount EverydayAccount { get; set; }
    public BankAccount SavingsAccount { get; set; }

    public BankAccountService(BankAccount everydayAccount, BankAccount savingsAccount)
    {
        EverydayAccount = everydayAccount;
        SavingsAccount = savingsAccount;
    }
}