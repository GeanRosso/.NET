using System;

namespace ApiContracts.UserFolder;

public class CreatePostDto
{
    public required string Title { get; set; }
    public required string Body { get; set; }
    public required int AuthorUserId{ get; set;}
}
