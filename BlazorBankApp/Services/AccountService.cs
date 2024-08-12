using BlazorBankApp.Models;

namespace BlazorBankApp.Services;

public class AccountService
{
    // Private list to store user objects (consider using more secure data storage solution in production)
    private readonly List<UserInfo> _users = new();
    
    // Constructor to initialise the service with a dummy user for testing purposes.
    public AccountService()
    {
        // Adding a dummy user for testing
        _users.Add(new UserInfo
        {
            Username = "Joe.Doe",
            Email = "joe.doe@example.com",
            Age = 30,
            Phone = "1234567890",
            Password = "Password123"
        });
    }
    
    private static bool IsValidUser(UserInfo newUserInfo)
    {
        // check all the fields of the user model if they are not null or empty. if any are, return false.
        // also check if the age is not less than or equal to 0 if so return false.
        return !(string.IsNullOrWhiteSpace(newUserInfo.Username) && string.IsNullOrWhiteSpace(newUserInfo.Email) &&
                 string.IsNullOrWhiteSpace(newUserInfo.Phone) && string.IsNullOrWhiteSpace(newUserInfo.Password) &&
                 newUserInfo.Age <= 0);
        // The function is then used to add a user if valid within the signup method.
    }
    
    public bool Signup(UserInfo newUserInfo) // This Method creates a new user
    {
        // If all validations pass, we use Add() method to add users data field of User model and return true as successfull values.
        if (!IsValidUser(newUserInfo)) 
            return false;
        // Add the new user to the list of users if the user is valid
        _users.Add(newUserInfo);
        return true;
    }

    // Method to authenticate a user login attempt.
    public bool Login(string email, string password)
    {
        // Attempt to find a user with the provided email and password.
        // Return true if a matching user is found, otherwise return false.
        return _users.FirstOrDefault(user => user.Email == email && user.Password == password) != null;
    }
}
