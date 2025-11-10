using System;
using System.Text.Json;
using ApiContracts.PostFolder;
using ApiContracts.UserFolder;

namespace BlazorApp.Services;

public class HttpPostService : IPostService
{
    private readonly HttpClient client;

    public HttpPostService(HttpClient client)
    {
        this.client = client;
    }
    public async Task<PostDto> AddPostAsync(CreatePostDto request)
    {
        var response = await client.PostAsJsonAsync("Post", request);
        var txt = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(txt);
        }
        return JsonSerializer.Deserialize<PostDto>(txt, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    }

    public async Task DeleatAsync(int id)
    {
        HttpResponseMessage httpResponseMessage = await client.DeleteAsync($"Post/{id}");
        string response = await httpResponseMessage.Content.ReadAsStringAsync();
        if(!httpResponseMessage.IsSuccessStatusCode)
        {
            throw new Exception(response);
        }
    }

    public async Task<List<PostDto>> GetManyAsync()
    {
        HttpResponseMessage httpResponseMessage = await client.GetAsync("Post");
        string response = await httpResponseMessage.Content.ReadAsStringAsync();
        if (!httpResponseMessage.IsSuccessStatusCode)
        {
            throw new Exception(response);
        }
        return JsonSerializer.Deserialize<List<PostDto>>(response, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;;
    }

    public async Task<PostDto> GetSingleAsync(int id)
    {
        HttpResponseMessage httpResponseMessage = await client.GetAsync($"Post/{id}");
        string response = await httpResponseMessage.Content.ReadAsStringAsync();
        if (!httpResponseMessage.IsSuccessStatusCode)
        {
            throw new Exception(response);
        }
        return JsonSerializer.Deserialize<PostDto>(response, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    }

    public async Task UpdatePostAsync(int id, CreatePostDto request)
    {
           HttpResponseMessage httpResponseMessage = await client.PutAsJsonAsync($"User/{id}", request);
        string response = await httpResponseMessage.Content.ReadAsStringAsync();
           if (!httpResponseMessage.IsSuccessStatusCode)
        {
            throw new Exception(response);
        }
    }
}
