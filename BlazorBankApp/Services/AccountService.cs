using BlazorBankApp.Models;

namespace BlazorBankApp.Services;

public class AccountService
{
    // Private list to store user objects (consider using more secure data storage solution in production)
    private readonly List<UserInfo> _users = new();
    private readonly UserSessionService _userSessionService;
    private readonly Dictionary<string, List<BankAccount>> _userAccounts = new();

    
    // Constructor to initialise the service with a dummy user for testing purposes.
    public AccountService(UserSessionService userSessionService)
    {
        // the userSessionService is injected into the AccountService constructor
        _userSessionService = userSessionService;
        // Add a dummy user for testing purposes
        _users.Add(new UserInfo
        {
            Username = "Joe.Doe",
            Email = "joe.doe@example.com",
            Age = 30,
            Phone = "1234567890",
            Password = "Password123",
        });
    }
    
    // This method is used to get the BankAccount objects associated with a users email in the dictionary (key-value pair)
    public List<BankAccount>? GetUserAccounts(string email)
    {
        // The GetValueOrDefault method returns the values associated with the key (email) in the dictionary.
        return _userAccounts.GetValueOrDefault(email);
    }
    
    // This method is used to set the BankAccount objects associated with a users email in the dictionary (key-value pair)
    public void SetUserAccounts(string email, List<BankAccount> accounts)
    {
        // The dictionary is updated with the new list of BankAccount objects associated with the email key.
        _userAccounts[email] = accounts;
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
    public UserInfo? Login(string email, string password)
    {
        // Attempt to find a user with the provided email and password.
        // if the user is not found, the method will return null. Thus, this will return false by the comparison statement.
        return _users.FirstOrDefault(user => user.Email == email && user.Password == password);
    }
}
