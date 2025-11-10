using System;
using System.Text.Json;
using ApiContracts.CommentFolder;

namespace BlazorApp.Services;

public class HttpCommentService : ICommentService
{

    private readonly HttpClient client;

    public HttpCommentService(HttpClient client)
    {
        this.client = client;
    }
    public async Task<CommentDto> AddCommentAsync(CreateCommentDto request)
    {
        HttpResponseMessage httpResponse = await client.PostAsJsonAsync("Comment", request);
        string response = await httpResponse.Content.ReadAsStringAsync();
        if (!httpResponse.IsSuccessStatusCode)
        {
            throw new Exception(response);
        }
        return JsonSerializer.Deserialize<CommentDto>(response, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    }

    public async Task DeleteAsync(int id)
    {
        HttpResponseMessage httpResponseMessage = await client.DeleteAsync($"Comment/{id}");
        string response = await httpResponseMessage.Content.ReadAsStringAsync();
        if (!httpResponseMessage.IsSuccessStatusCode)
        {
            throw new Exception(response);
        }

    }

    public async Task<List<CommentDto>> GetByPostIdAsync(int postId)
     => await client.GetFromJsonAsync<List<CommentDto>>($"/comment?postId={postId}")
       ?? new List<CommentDto>();
    

    public async Task<List<CommentDto>> GetManyAsync()
    {
        HttpResponseMessage httpResponseMessage = await client.GetAsync("Comment");
        string response = await httpResponseMessage.Content.ReadAsStringAsync();
        if (!httpResponseMessage.IsSuccessStatusCode)
        {
            throw new Exception(response);
        }
        return JsonSerializer.Deserialize<List<CommentDto>>(response, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    }
    

    public async Task<CommentDto> GetSingleAsync(int id)
    {
        HttpResponseMessage httpResponseMessage = await client.GetAsync($"User/{id}");
        string response = await httpResponseMessage.Content.ReadAsStringAsync();
        if (!httpResponseMessage.IsSuccessStatusCode)
        {
            throw new Exception(response);
        }
        return JsonSerializer.Deserialize<CommentDto>(response, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    }

    public async Task UpdateCommentAsync(int id, CreateCommentDto request)
    {
        HttpResponseMessage httpResponseMessage = await client.PutAsJsonAsync($"Comment/{id}", request);
        string response = await httpResponseMessage.Content.ReadAsStringAsync();
        if (!httpResponseMessage.IsSuccessStatusCode)
        {
            throw new Exception(response);
        }
    }
}
