using System;
using RepositoryContracts;
namespace CLI.UI.Manage_Post;

public class ViewSinglePostView
{
    private Postinterface postinterface;
    private CommentInterface commentInterface;

    public ViewSinglePostView(Postinterface postinterface, CommentInterface commentInterface)
    {
        this.postinterface = postinterface;
        this.commentInterface = commentInterface;
    }
    public async Task ShowAsync()
    {
        Console.WriteLine("Enter post Id: ");
        int postIdInput = Convert.ToInt32(Console.ReadLine());
        Post? post = await postinterface.GetSingleAsync(postIdInput);
        if (post != null)
        {
            System.Console.WriteLine($"ID: {post.Id},Title :{post.Title} Body: {post.Body}, UserID: {post.UserId}");
          IQueryable<Comment> comments = commentInterface.GetManyAsync().Where(c => c.PostId == postIdInput);
          Console.WriteLine($"__Comment of post : {post.Title}");
              foreach (var comment in comments)
              {
                  Console.WriteLine($"\nUser ID: {comment.UserId}" +
                      $"\n => {comment.Body}");
              }        }

        else
        {
            Console.WriteLine("Comment not found");
        }

    }
}
