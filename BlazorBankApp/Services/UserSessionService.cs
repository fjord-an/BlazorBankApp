using BlazorBankApp.Models;

namespace BlazorBankApp.Services
{
    public class UserSessionService
    {
        // Property to hold the current logged-in user's details
        public UserInfo? CurrentUser { get; private set; }
        // This boolean property checks whether if a current user is logged in or not.
        public bool IsLoggedIn { get; private set; }
        // OnLoginStateChanged event is triggered when the login state changes. The StateHasChanged is a built-in Razor
        // method which re-renders the component to dynamically update the UI. The Action delegate is used to trigger
        // the StateHasChanged method. It is subscribed to in the NavBar component on its OnInitialized method, thus
        // updating the UI whenever OnLoginStateChanged.invoke() is called within the Login/Logout functions.
        // Hamedani, M. (Director). (2015). Delegates — C# Advanced Course [Video recording].
        public event Action? OnLoginStateChanged; // will show account controls if user is logged in
        
        
        // Method to log in a user
        public void Login(UserInfo userInfo)
        {
            // Set the current user to the provided user
            CurrentUser = userInfo;
            // Set the IsLoggedIn property to true
            IsLoggedIn = true;
            OnLoginStateChanged?.Invoke();
            // Trigger the OnLoginStateChanged event.
            // This utilizes the Action delegate to change the login state, which alters the navbar component.
        }
        // Method to log out the current user
        public void Logout()
        {
            CurrentUser = null;
            IsLoggedIn = false;
            OnLoginStateChanged?.Invoke();
            // Trigger the OnLoginStateChanged event.
        }
    }
}
