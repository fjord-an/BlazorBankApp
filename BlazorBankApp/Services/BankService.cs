using BlazorBankApp.Models;

namespace BlazorBankApp.Services;
public class BankService
{
    // Variable to store the current balance
    private double Balance { get; set; }
    
    // This method calculate the Deposit
    public void Deposit(double amount)
    {
        // we check if amount as argument is greater than 0 then we add value of the balance to the amount.
        if (amount > 0)
        {
            Balance += amount;
        }
    }

    // This method calcuate the Withdraw
    public bool Withdraw(double amount)
    {
        // we check if the amount is greater than 0 and also the balance is greater or equal to amount that user input then we subtract the amount of the balance.
        if (amount > 0 && Balance >= amount)
        {
            Balance -= amount;
            return true;
        }
        return false;
    }

    // This method is only return the balance we need this method in other class and pages.
    public double GetBalance()
    {
        return Balance;
    }  
}