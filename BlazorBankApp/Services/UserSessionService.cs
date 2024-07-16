using BlazorBankApp.Models;
using System;

namespace BlazorBankApp.Services
{
    public class UserSessionService
    {
        // Property to hold the current logged-in user's details
        public User CurrentUser { get; private set; }
        // This boolean property checks whether if a current user is logged in or not.
        public bool IsLoggedIn => CurrentUser != null;

        // Method to log in a user
        public void Login(User user)
        {
            // Set the current user to the provided user
            CurrentUser = user;
            
        }
        // Method to log out the current user
        public void Logout()
        {
            CurrentUser = null;
            
        }
        
    }
}
