using Data;

namespace BusinessLogic.UserManagement
{
    public class UserServiceModel : IUniqueModel
    {
        public UserServiceModel(int id, string login, string password, UserStatus userStatus)
        {
            Id = id;
            Login = login;
            Password = password;
            UserStatus = userStatus;
        }

        public int Id { get; }
        public string Login { get; }
        public string Password { get; }
        public UserStatus UserStatus { get; }
    }
}
