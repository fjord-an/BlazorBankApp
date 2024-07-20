using BlazorBankApp.Models;

namespace BlazorBankApp.Services
{
    public class UserSessionService
    {
        // Property to hold the current logged-in user's details

        public User CurrentUser { get; private set; }

        // This boolean property checks whether if a current user is logged in or not.
        public bool IsLoggedIn { get; private set; }
        public event Action? OnLoginStateChanged;
        // Method to check if THE USERS account status, updates the login state and triggers an OnLoginStateChanged event
        
        // Method to log in a user
        public void Login(User user)
        {
            // Set the current user to the provided user
            CurrentUser = user;
            // Set the IsLoggedIn property to true
            IsLoggedIn = true;
            OnLoginStateChanged.Invoke();
            // Trigger the OnLoginStateChanged event.
            // This utilizes the Action delegate to change the login state, which is reciprocated in the NavBar razor component.
        }
        // Method to log out the current user
        public void Logout()
        {
            CurrentUser = null;
            IsLoggedIn = false;
            OnLoginStateChanged.Invoke();
        }
        
    }
}
