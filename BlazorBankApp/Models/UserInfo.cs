using System.ComponentModel.DataAnnotations;
//by using System.ComponentModel.DataAnnotations; we can use Built in Client Side Validations for the HTML Fields

namespace BlazorBankApp.Models;
public class UserInfo
{
    // Models/UserInfo.cs
    // this is the user class that we can get or retrieve the data from users and with set we can assign value to them. 
    // https://www.w3schools.com/cs/cs_properties.php
    
    // variable of Username of the user class with type string (text)
    public string? Username { get; set; } //required field, it cannot be null
    
    // TODO: Provide source:
    // These data annotations within the square brackets are built in C# Client Side Validations for the Fields. They are
    // Metadata that provides additional information about the data that a class/property represents.
    [Required][EmailAddress] 
    // Required and Email Address annotations to make sure the email is not null and is in the correct format
    public required string Email { get; set; } //it is set as required, it cannot be null
    
    [Required] 
    public int Age { get; set; } // will initialize as 0
    
    // TODO: Provide source:
    // the Regular Expression annotations will make sure the phone number follows the Regex pattern, if not it will show the error message
    [Phone][RegularExpression(@"^\+?\d{10,15}$", ErrorMessage = "The phone number is not a valid format.")]
    public string? Phone { get; set; }
    
    [Required]
    public required string Password { get; set; } //it is set as required, it cannot be null
    
    // Property to store the user's bank accounts and balances so that each user has a unique BankAccount instance
    // with their own balances. It is also extensible to allow for future implementations of the bank account types.
    public List<BankAccount> Accounts { get; set; } = new List<BankAccount>();
}