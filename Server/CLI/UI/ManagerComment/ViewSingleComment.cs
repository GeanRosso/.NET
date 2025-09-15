using System;
using RepositoryContracts;
namespace CLI.UI.ManagerComment;

public class ViewSingleComment
{
    private CommentInterface commentInterface;

    public ViewSingleComment(CommentInterface commentInterface)
    {
        this.commentInterface = commentInterface;
    }
    public async Task ShowAsync()
    {
        Console.WriteLine("Enter comment Id: ");
        int commentIdInput = Convert.ToInt32(Console.ReadLine());
        Comment? comment = await commentInterface.GetSingleAsync(commentIdInput);
        if (comment != null)
        {
            System.Console.WriteLine($"ID: {comment.Id}, Body: {comment.Body}, PostID: {comment.PostId}, UserID: {comment.UserId}");
        }
        else
        {
            Console.WriteLine("Comment not found");
        }

    }
}
