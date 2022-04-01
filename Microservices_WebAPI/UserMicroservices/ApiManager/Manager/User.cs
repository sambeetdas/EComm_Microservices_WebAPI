using DataAccess.IRepository;
using Model;
using ServiceManager.IManager;

namespace ServiceManager.Manager
{
    public class User : IUser
    {
        private readonly IUserRepository _userRepository;
        public User(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserModel ProcessUser(UserModel user)
        {
            UserModel result = _userRepository.ProcessUser(user);
            return result;
        }
        public UserModel GetUserById(Guid userId)
        {
            UserModel result = _userRepository.GetUserById(userId);
            return result;
        }

        public UserModel GetUserByUserName(string username)
        {
            UserModel result = _userRepository.GetUserByUserName(username);
            return result;
        }

       
    }
}
