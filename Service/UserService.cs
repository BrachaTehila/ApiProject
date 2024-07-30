using DTO;
using Entities;
using Repository;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UsersTbl> getUserByEmailAndPassword(UserLoginDTO userLoginDTO)
        {
            return await _repository.getUserByEmailAndPassword(userLoginDTO);
        }

        public async Task<UsersTbl> addUser(UsersTbl user)
        {
            int level = checkPassword(user.Password);
            if (level > 2)
                return await _repository.addUser(user);
            return null;
        }

        public async Task updateUser(UsersTbl value)
        {
            await _repository.updateUser(value);
        }

        public int checkPassword(string password)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password);
            return result.Score;
        }
    }
}
