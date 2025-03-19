using LearningVocab.Models;

namespace LearningVocab.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
    }
}
