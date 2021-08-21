namespace _01_Framework.Application
{
    public interface IAuthHelper
    {
        void Login(AuthViewModel account);
        void SignOut();
        bool IsAuthenticated();
        AuthViewModel GetCurrentAccount();
    }
}
