using System;
using RepositoryContracts;

namespace CLI.UI;

public class CliApp
{
    public CommentInterface commentInterface { get; set; }
    public UserInterface userInterface { get; set; }
    private Postinterface postinterface { get; set; }

    public CliApp(CommentInterface commentInterface, UserInterface userInterface, Postinterface postinterface)
    {
        this.commentInterface = commentInterface;
        this.userInterface = userInterface;
        this.postinterface = postinterface;
    }

    internal async Task StartAsync()
    {
        throw new NotImplementedException();
    }
}
