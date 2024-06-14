using System.Text.RegularExpressions;

namespace ClarkCodingChallenge.BusinessLogic
{
    public class ContactsService
    {
        /* Checks if a given email is valid using a regular expression.
         * This isn't the only way that can be used to check if something
         * is a valid email but for an exercise like this it should be fine.
         */
        public static bool IsValidEmail(string email)
        {
            // Short circuit check if nothing was actually submitted.
            if (string.IsNullOrEmpty(email))
                return false;
            try
            {
                return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase);
            }
            catch
            {
                return false;
            }
        }
    }
}
