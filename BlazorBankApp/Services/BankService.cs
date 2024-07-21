using BlazorBankApp.Models;

namespace BlazorBankApp.Services;
public class BankService
{
    // Variable to store the current balance
    private double Balance { get; set; }
    
    // This method is for getting the balance for other classes in the project
    public double GetBalance()
    {
        return Balance;
    }
    
    // This method calculates the Deposit
    public void Deposit(double amount)
    {
        // check if parameter value is valid (greater than 0). If it is, add the value of the parameter to the amount.
        if (amount > 0)
        {
            Balance += amount;
        }
    }

    // Calculate the Withdrawal
    public bool Withdraw(double amount)
    {
        // Check if the parameter is valid, and if the balance is greater than the amount. If it is, subtract the amount from the balance.
        if (amount > 0 && Balance >= amount)
        {
            Balance -= amount;
            return true;
        }
        return false;
    }
}