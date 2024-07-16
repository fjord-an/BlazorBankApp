// accessing the user class from Models
using System.ComponentModel.DataAnnotations;

namespace BlazorBankApp.Models;
// this is the user class
public class User
{
    // Models/User.cs
    // this is the user class that we can get or retireve the data from users and with set we can assign value to them. 
    // https://www.w3schools.com/cs/cs_properties.php
    // variabe of Username of the user class with type string (text)
    
    public string Username { get; set; }
    // variabe of Email of the user class with type string (text)
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    // variabe of Age of the user class with type string (text)
    [Required]
    public int Age { get; set; }
    // variabe of Phone of the user class with type integer (numbers)
    [Phone]
    [RegularExpression(@"^\+?\d{10,15}$", ErrorMessage = "The phone number is not a valid format.")]
    public string Phone { get; set; }
    // variabe of Password of the user class with type string (text)
    [Required]
    public string Password { get; set; }
    
}