using LearningVocab.Datas;
using LearningVocab.Interface;
using Microsoft.EntityFrameworkCore;

namespace LearningVocab.Services.User
{
    public class UserService : IUserService
    {
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
