using System.Collections.Generic;
using System.Threading.Tasks;
using webAPI.Models;

namespace webAPI.Data
{
    public interface IUserRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<IEnumerable<User>> GetUsers();
         Task<User> GetUser(int Id);
         Task<Photo> GetPhoto(int Id);
         Task<Photo> GetMainPhoto(int userId);

    }
}