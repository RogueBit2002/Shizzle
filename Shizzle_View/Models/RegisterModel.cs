namespace Shizzle.View.Models
{
    public class RegisterModel
    {
        public readonly string email;
        public readonly string password;
        public readonly string name;

        public readonly string emailError;

        public RegisterModel(string emailError)
        {
            this.emailError = emailError;
        }
    }
}
