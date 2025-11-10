using System;

namespace ApiContracts.PostFolder;

public class PostDto
{
 public required int Id { get; set; }
 public required string Title { get; set; }
 public required string Body { get; set; }
 public required int AuthorUserId { get; set; }

    public string AuthorName { get; set; } = "";
}
