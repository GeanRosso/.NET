using System;
using ApiContracts.PostFolder;
using ApiContracts.UserFolder;

namespace BlazorApp.Services;

public interface IPostService
{
    public Task<PostDto> AddPostAsync(CreatePostDto request);

    public Task DeleatAsync(int id);

    public Task UpdatePostAsync(int id, CreatePostDto request);

    public Task<PostDto> GetSingleAsync(int id);

    public Task<List<PostDto>> GetManyAsync();
}
