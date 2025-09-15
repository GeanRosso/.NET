using System;
using RepositoryContracts;

namespace CLI.UI.Manage_Post;

public class PostListView
{
    private Postinterface postInterface;

    public PostListView(Postinterface postInterface)
    {
        this.postInterface = postInterface;
    }

    public async Task ShowAsync()
    {
      var posts = postInterface.GetManyAsync(); 

    Console.WriteLine("\n=== All Posts ===");

    foreach (var post in posts)
    {
        Console.WriteLine($"ID: {post.Id}, Title: {post.Title}, UserId: {post.UserId}");
        Console.WriteLine($"   Body: {post.Body}");
    }
    }
}
