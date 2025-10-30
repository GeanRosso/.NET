using System;
using ApiContracts.UserFolder;

namespace BlazorApp.Services;

public interface IUserService
{
    public Task<UserDto> AddUserAsync(CreateUserDto request);
    public Task UpdateUserAsync(int id, CreateUserDto request);
    public Task DeleteAsync(int id);
    public Task<UserDto> GetSingleAsync(int id);
   public Task<List<UserDto>> GetManyAsync();
}
