using BusinessLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public static class HelperController
    {
        public const string Error = "Error";

        public static List<ErrorViewModel> Errors;

        static HelperController()
        {
            Errors = new List<ErrorViewModel>();
        }

        public static void ClearErrors()
        {
            Errors.Clear();
        }

        public static void AddError(string code, string description, string requiestId = null)
        {
            Errors.Add(new ErrorViewModel(code, description, requiestId));
        }

        public static void AddErrors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                AddError(error.Code, error.Description);
            }
        }

        public static async Task<User> GetLoggedUser(this UserManager<User> userManager, Controller controller)
        {
            //string username = User.Claims.First(c => c.Type == ClaimTypes.Name).Value;
            if (string.IsNullOrEmpty(controller.User.Identity.Name))
            {
                AddError("Authentication", "The user is not logged yet!");
                throw new ArgumentNullException("User is not logged!");
            }

            string username = controller.User.Identity.Name;
            User user = await userManager.FindByNameAsync(username);

            if (user == null)
            {
                string message = "There is no user with that name!";
                userManager.Logger.Log(LogLevel.Error, message);
                AddError("Argument", message);
                throw new ArgumentException(message);
            }

            return user;
        }
    }
}

