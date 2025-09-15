using System;
using CLI.UI.ManageUser;
using RepositoryContracts;
namespace CLI.UI.ManagerComment;

public class ManageCommentView
{
    private CommentInterface commentInterface;

    private ViewSingleComment viewSingleComment;

    private CreateCommentView createCommentView;

    public ManageCommentView(CommentInterface commentInterface)
    {
        this.commentInterface = commentInterface;
        this.createCommentView = new CreateCommentView(commentInterface);
        this.viewSingleComment = new ViewSingleComment(commentInterface);
    }
    public async Task ShowMenuAsync()
    {
        while (true)
        {
            Console.WriteLine("\n=== Manage Comment ===");
            Console.WriteLine("1. Create Comment");
            Console.WriteLine("2. View Single Comment Using Id");
            Console.WriteLine("0. Back");

            string? choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    await createCommentView.ShowAsync();
                    break;
                case "2":
                    await viewSingleComment.ShowAsync();
                    break;
                case "0":
                    return;
            }
        }
    }
}