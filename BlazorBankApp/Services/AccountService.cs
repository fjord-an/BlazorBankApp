using BlazorBankApp.Models;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Data.Sqlite;

namespace BlazorBankApp.Services;

public class AccountService
{
    // List to store user data
    private readonly List<UserInfo> _users = new();
    
    // Constructor to initialise the service with a dummy user for testing
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
        
        HashedPassword(newUserInfo.Password, newUserInfo.Email);
        
        // Add the new user to the list of users if the user is valid
        _users.Add(newUserInfo);
        return true;
    }
    
    void HashedPassword(string plainTextPassword, string userName)
        {
            string Hash(string password, out byte[] salt) 
                // output parameter salt is declared in the method signature
                // the plain text password is hashed and the salt is generated
            {
                salt = RandomNumberGenerator.GetBytes(HashParameters.KeySize);
                var hash = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(password), salt,
                    HashParameters.Iterations, HashAlgorithmName.SHA512, HashParameters.KeySize);
                /* The Rfc2898DeriveBytes.Pbkdf2 method is used to hash the password with the salt. It takes 5 parameters:
                     1. The password to hash, 2. The salt to use, 3. The number of iterations to perform on the password,
                     4. The hash algorithm to use, 5. The key size of the hashed password. The Iterations and Keysize are
                     defined in the HashParameters.cs file for convenience and consistency throughout the namespace */
                    
                return Convert.ToHexString(hash);
                // The hashed password is stored as a hexadecimal string to store in the file. It would be impossible to store
                // the hashed password as a byte array in the file. The hexadecimal string is converted back to a byte array
                // with the Convert.FromHexString when the hashed password needs to be compared to the user's input
            }

            var hash = Hash(plainTextPassword, out byte[] salt);
            //output parameter. the out keyword is used to pass a reference of the salt variable to the Hash method
            //BillWagner. (2024, March 30). out keyword—C# reference.
            //https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/out
            
            string hexSalt = Convert.ToHexString(salt); // The salt is also stored in the file as a hexadecimal string
            // TODO: Possibly causing the error, wrong path:
            // SQLite connection string, adjust the DataSource to your database file path
            string connectionString = "Data Source=C:\\Users\\Jordan\\Programs\\projects\\BlazorBankApp\\BlazorBankApp\\BlazorBankApp\\identifier.sqlite;";
            
            
            string sql = "INSERT INTO Users (Email, Hash, Salt) VALUES (@Username, @PasswordHash, @Salt);";

            // Using block ensures that the connection is closed and disposed properly
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqliteCommand(sql, connection))
                {
                    // Use parameters to prevent SQL injection
                    command.Parameters.AddWithValue("@Username", userName);
                    command.Parameters.AddWithValue("@PasswordHash", hash);
                    command.Parameters.AddWithValue("@Salt", hexSalt);

                    command.ExecuteNonQuery();
                }
            }
            
            // finally, the user is redirected to the login page and will log in with their new credentials automatically
            // Verify.Login(userName, plainTextPassword, hash, salt);
        }


    // Authenticate the user
    public bool Login(string email, string password)
    {
        // Find and return the user that matches the provided email and password. if found, return true.
        // if the user is not found, the method will return null. Thus, this will return false by the comparison statement.
        return _users.FirstOrDefault(user => user.Email == email && user.Password == password) != null;
        
        // TODO: proposed future implementation in next update, incorporating hashing algorithm
        //     var user = _users.FirstOrDefault(u => u.Email == email);
        //     if (user != null && user.Password == password) // In a real application, use a secure password comparison method here
        //     {
        //         return true;
        //     }
        //     return false;
        // }
    }
}