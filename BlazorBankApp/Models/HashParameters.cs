//# Created by Jordan Pacey. Student ID: A00144357

using System.Security.Cryptography;

namespace BlazorBankApp.Models;

public class HashParameters
{ // This class is used to store the parameters for the password hashing algorithm
    public const int KeySize = 64;          // Hashed key size in bytes
    public const int Iterations = 5000;   // Number of hash iterations to perform on the password
}