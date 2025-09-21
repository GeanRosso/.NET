using System;
using RepositoryContracts;
using System.Text.Json;
using System.Threading.Tasks;

namespace FileRepository;

public class PostFileRepository : Postinterface
{
    private readonly string filePath = "Posts.json";

    public PostFileRepository()
    {
        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "[]");
        }
    }
    public async Task<Post> AddAsync(Post post)
    {
        string postsAsJson = await File.ReadAllTextAsync(filePath);
        List<Post> posts = JsonSerializer.Deserialize<List<Post>>(postsAsJson)!;
        //If there are no posts, this will start IDs at 2 (because you set 1 then +1).
        int maxID = posts.Count > 0 ? posts.Max(p => p.Id) : 0;
        post.Id = maxID + 1;
        posts.Add(post);
        postsAsJson = JsonSerializer.Serialize(posts);
        await File.WriteAllTextAsync(filePath, postsAsJson);
        return post;
    }

    public async Task DeleteAsync(int id)
    {
        string postsAsJson = await File.ReadAllTextAsync(filePath);
        List<Post> posts = JsonSerializer.Deserialize<List<Post>>(postsAsJson)!;

        Post? postToRemove = posts.SingleOrDefault(p => p.Id == id);
        if (postToRemove == null)
            throw new InvalidOperationException($"Post with ID {id} not found.");

        posts.Remove(postToRemove);
        postsAsJson = JsonSerializer.Serialize(posts);
        await File.WriteAllTextAsync(filePath, postsAsJson); 
    }


    public async Task<Post> GetSingleAsync(int id)
    {
        string postsAsJson = await File.ReadAllTextAsync(filePath);
        List<Post> posts = JsonSerializer.Deserialize<List<Post>>(postsAsJson)!;
        return posts.SingleOrDefault(p => p.Id == id)!;
    }

    public async Task UpdateAsync(Post post)
    {
            string postsAsJson = await File.ReadAllTextAsync(filePath);
        List<Post> posts = JsonSerializer.Deserialize<List<Post>>(postsAsJson)!;

        int index = posts.FindIndex(p => p.Id == post.Id);
        if (index == -1)
            throw new InvalidOperationException($"Post with ID {post.Id} not found.");

        posts[index] = post;
        postsAsJson = JsonSerializer.Serialize(posts);
        await File.WriteAllTextAsync(filePath, postsAsJson);
    }

    IQueryable<Post> Postinterface.GetManyAsync()
    {
        string postsAsJson =  File.ReadAllText(filePath);
        List<Post> posts = JsonSerializer.Deserialize<List<Post>>(postsAsJson)!;
        return posts.AsQueryable();
    }
}
