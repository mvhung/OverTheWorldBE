using LearningVocab.Datas;
using LearningVocab.Interface;
using LearningVocab.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningVocab.Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task<IEnumerable<User>> GetUsers()
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

        public async Task<User> GetUserById(string id)
        {
            using(var context = new AppDbContext())
            {
                var user = await context.Users.FirstOrDefaultAsync(x => x.UserId == id);
                if (user != null)
                {
                    return user;
                }
                return new User { };
            }
        }
        public async Task<User> GetUserByName(string userName)
        {
            using (var context = new AppDbContext())
            {
                var user = await context.Users.FirstOrDefaultAsync(x => x.UserName == userName);
                if (user != null)
                {
                    return user;
                }
                return new User { };
            }
        }
        public async Task<int> AddUser(User user)
        {
            using (var context = new AppDbContext())
            {
                context.Users.Add(user);
                return await context.SaveChangesAsync();
            }
        }

        public async Task<int> UpdateUser(User user)
        {
            using  (var context = new AppDbContext())
            {
                context.Users.Update(user);
                return await context.SaveChangesAsync();
            }
        }

        public async Task<int> DeleteUser(string id)
        {
            using (var context = new AppDbContext())
            {
                var user = context.Users.FirstOrDefault(x => x.UserId == id);
                if (user != null)
                {
                    context.Users.Remove(user);
                    return await context.SaveChangesAsync();
                }
                return 0;
            }
        }
    }
}
