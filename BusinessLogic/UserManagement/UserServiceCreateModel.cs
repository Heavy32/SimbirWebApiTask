using Data;

namespace BusinessLogic.UserManagement
{
    public class UserServiceCreateModel
    {
        public UserServiceCreateModel(string login, string password, UserStatus userStatus)
        {
            Login = login;
            Password = password;
            UserStatus = userStatus;
        }

        public string Login { get; }
        public string Password { get; }
        public UserStatus UserStatus { get; }
    }
}
