using System;
using ApiContracts.CommentFolder;

namespace BlazorApp.Services;

public interface ICommentService
{
    public Task<CommentDto> AddCommentAsync(CreateCommentDto request);
    public Task UpdateCommentAsync(int id, CreateCommentDto request);
    public Task DeleteAsync(int id);
    public Task<CommentDto> GetSingleAsync(int id);
    public Task<List<CommentDto>> GetManyAsync();
   
   Task<List<CommentDto>> GetByPostIdAsync(int postId);
}
