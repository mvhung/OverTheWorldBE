using LearningVocab.Datas;
using LearningVocab.Interface;
using LearningVocab.Utils;
using Microsoft.EntityFrameworkCore;

namespace LearningVocab.Services.User
{
    public class UserService(
        IUserRepository userRepository
        ) : IUserService
    {
        public async Task<int> AddUser(Models.User user)
        {
            user.UserId = SequentialGuidGenerator.NewGuid().ToString();
            return await userRepository.AddUser(user);
        }

        public async Task<int> DeleteUser(string id)
        {
            return await userRepository.DeleteUser(id);
        }

        public async Task<Models.User> GetUserById(string id)
        {
            return await userRepository.GetUserById(id);
        }

        public async Task<Models.User> GetUserByName(string id)
        {
            return await userRepository.GetUserByName(id);
        }

        public async Task<int> UpdateUser(Models.User user)
        {
            return await userRepository.UpdateUser(user);
        }
        public async Task<IEnumerable<Models.User>> GetUsers()
        {
            using (var context = new AppDbContext())
            {
                var users = await context.Users.ToListAsync();
                if (users != null)
                {
                    return users;
                }
                return new List<Models.User>() { new Models.User { } };
            };
        }
    }
}
