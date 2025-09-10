using System;

namespace RepositoryContracts;

public interface UserInterface
{
   Task<User> AddAsync(User user);
    Task UpdateAsyncU(User user);
    Task DeleteAsync(int id);
    Task<User> GetSingleAsync(int id);
    IQueryable<User> GetManyAsync();
}
