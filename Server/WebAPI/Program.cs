using FileRepository;
using RepositoryContracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddScoped<Postinterface, PostFileRepository>();
builder.Services.AddScoped<UserInterface, UserFileRepository>();
builder.Services.AddScoped<CommentInterface, CommendFileRepository>();

var app = builder.Build();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
   // app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.Run();