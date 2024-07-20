using BlazorBankApp.Models;

namespace BlazorBankApp.Services;

public class BankService
{
    // List to store user data
    private List<User> users = new List<User>();
    // Variable to store the current balance
    private double balance;

    // Constructor to initialise the service
    public BankService()
    {
        // Adding a dummy user for testing
        users.Add(new User
        {
            Username = "Joe.Doe",
            Email = "joe.doe@example.com",
            Age = 30,
            Phone = "1234567890",
            Password = "Password123"
        });
        
        balance = 0; // Initial balance and set to 0
    }

    // This Method to sign up a new user
    public bool Signup(User newUser)
    {
        // we conditionally check if the user input is not null or any empty space (whitespace)
        // we also check if the age is not less than or equal to 0 if so return false.
        if (string.IsNullOrWhiteSpace(newUser.Username) || string.IsNullOrWhiteSpace(newUser.Email) ||
            string.IsNullOrWhiteSpace(newUser.Phone) || string.IsNullOrWhiteSpace(newUser.Password) || newUser.Age <= 0)
        {
            return false;
        }
        // If all validations pass, we use Add() method to add users data field of User model and return true as successfull values.
        users.Add(newUser);
        return true;
    }

    // This Method to authenticate a user
    public User Login(string email, string password)
    {
        // Find and return the user that matches the provided email and password
        return users.FirstOrDefault(user => user.Email == email && user.Password == password);
    }

    // This method calcuate the Deposit
    public void Deposit(double amount)
    {
        // we check if amount as argument is greater than 0 then we add value of the balance to the amount.
        if (amount > 0)
        {
            balance += amount;
        }
    }

    // This method calcuate the Withdraw
    public bool Withdraw(double amount)
    {
        // we check if the amount is greater than 0 and also the balance is greater or equal to amount that user input then we subtract the amount of the balance.
        if (amount > 0 && balance >= amount)
        {
            balance -= amount;
            return true;
        }
        return false;
    }

    // This method is only return the balance we need this method in other class and pages.
    public double GetBalance()
    {
        return balance;
    }  
}