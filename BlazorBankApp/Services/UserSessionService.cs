using BlazorBankApp.Models;

namespace BlazorBankApp.Services
{
    public class UserSessionService
    {
        // Property to hold the current logged-in user's details
        public UserInfo? CurrentUser { get; private set; }
        // This boolean property checks whether if a current user is logged in or not.
        public bool IsLoggedIn { get; private set; }
        // This event is triggered when the login state changes, executing the StateHasChanged method in the navbar component.
        // The StateHasChanged is a built-in Razor method which re-renders the component to dynamically update the UI.
        public event Action? OnLoginStateChanged; // will show account controls if user is logged in
        
        
        // Method to log in a user
        public void Login(UserInfo userInfo)
        {
            // Set the current user to the provided user
            CurrentUser = userInfo;
            // Set the IsLoggedIn property to true
            IsLoggedIn = true;
            OnLoginStateChanged.Invoke();
            // Trigger the OnLoginStateChanged event.
            // This utilizes the Action delegate to change the login state, which is altered in the navbar component.
        }
        // Method to log out the current user
        public void Logout()
        {
            CurrentUser = null; // remove the current user
            IsLoggedIn = false; // set the IsLoggedIn property to false
            OnLoginStateChanged.Invoke(); // Trigger the OnLoginStateChanged event delegate in the navbar component
        }
    }
}
