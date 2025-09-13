using System;
using System.Reflection.Metadata;
using InMemory;
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
        while (true)
        {
            Console.WriteLine("\n=== Main Menu ===");
            Console.WriteLine("1. Manage User");
            Console.WriteLine("2. Manage Post");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await ManageUsersAsync();
                    break;
                case "2":
                    await ManagePostsAsync();
                    break;
            }
        }
    }

    private async Task ManagePostsAsync()
    {
        Console.WriteLine("\n=== Main Menu ===");
        Console.WriteLine("1. create Post");
        string? choice = Console.ReadLine();
        switch (choice)
        {
            
        }
    }

    private async Task ManageUsersAsync()
    {
        while (true)
        {
            Console.WriteLine("\n=== Main Menu ===");
            Console.WriteLine("1. create User");
            Console.WriteLine("2. list of users");
            string? choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    await CreateUserAsync();
                    break;
                case "2":
                    await ListUsersAsync();
                    break;
            }
        }
    }

    private async Task ListUsersAsync()
    {
        var users = userInterface.GetManyAsync();
        Console.WriteLine("\n=== All Users ===");
        foreach (var user in users)
        {
            Console.WriteLine($"ID: {user.Id}, Username: {user.Username}");
        }
    }

    private async Task CreateUserAsync()
    {
        Console.Write("Enter username: ");
        string? username = Console.ReadLine();

        Console.Write("Enter password (numbers only): ");
        string? input = Console.ReadLine();

        if (!int.TryParse(input, out int password))
        {
            Console.WriteLine("Invalid password. Please enter digits only.");
            return;
        }
        var user = new User
        {
            Username = username,
            Passsword = password
        };
        var addedUser = await userInterface.AddAsync(user);
        Console.WriteLine("User created successfully");
    }
}