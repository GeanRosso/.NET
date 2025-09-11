using CLI.UI;
using InMemory;
using RepositoryContracts;


Console.WriteLine("Starting CLI app.....");
UserInterface userInterface = new InMemoryUser();
CommentInterface commentInterface = new InMemoryComment();
Postinterface postinterface = new InMemoryPost();

CliApp cliApp = new CliApp(commentInterface, userInterface, postinterface);
await cliApp.StartAsync();


