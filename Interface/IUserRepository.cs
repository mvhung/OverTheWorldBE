using LearningVocab.Models;

namespace LearningVocab.Interface
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetUsers();
        public Task<User> GetUserById(string id);
        public Task<User> GetUserByName(string id);
        public Task<int> AddUser(User user);
        public Task<int> UpdateUser(User user);
        public Task<int> DeleteUser(string id);

    }
}
