namespace Shizzle.View.Models
{
    public class LoginModel
    {
        public readonly string email;
        public readonly string password;
        public readonly bool failedAttempt;
        public readonly string redirect;

        public LoginModel(bool failedAttempt, string redirect)
        {
            this.failedAttempt = failedAttempt;
            this.redirect = redirect;
        }
    }
}
