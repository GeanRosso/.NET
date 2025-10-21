using System;

namespace ApiContracts.UserFolder;

public class CreateUserDto
{
    public required string Username { get; set; }
    public required int Password { get; set; }
}
