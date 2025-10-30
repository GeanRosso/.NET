using System;
using ApiContracts.UserFolder;
using System.Text.Json; 

namespace BlazorApp.Services;

public class HttpUserService : IUserService
{
    private readonly HttpClient client;

    public HttpUserService(HttpClient client)
    {
        this.client = client;
    }
    public async Task<UserDto> AddUserAsync(CreateUserDto request)
    {
        HttpResponseMessage httpResponse = await client.PostAsJsonAsync("User", request);
        string response = await httpResponse.Content.ReadAsStringAsync();
        if (!httpResponse.IsSuccessStatusCode)
        {
            throw new Exception(response);
        }
        return JsonSerializer.Deserialize<UserDto>(response, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    }

    public async Task DeleteAsync(int id)
    {
        HttpResponseMessage httpResponseMessage = await client.DeleteAsync($"User/{id}");
        string response = await httpResponseMessage.Content.ReadAsStringAsync();
        if (!httpResponseMessage.IsSuccessStatusCode)
        {
            throw new Exception(response);
        }

    }

    public async Task<List<UserDto>> GetManyAsync()
    {
        HttpResponseMessage httpResponseMessage = await client.GetAsync("User");
        string response = await httpResponseMessage.Content.ReadAsStringAsync();
        if (!httpResponseMessage.IsSuccessStatusCode)
        {
            throw new Exception(response);
        }
        return JsonSerializer.Deserialize<List<UserDto>>(response, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    }

    public async Task<UserDto> GetSingleAsync(int id)
    {
        HttpResponseMessage httpResponseMessage = await client.GetAsync($"User/{id}");
        string response = await httpResponseMessage.Content.ReadAsStringAsync();
        if (!httpResponseMessage.IsSuccessStatusCode)
        {
            throw new Exception(response);
        }
        return JsonSerializer.Deserialize<UserDto>(response, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    }

    public async Task UpdateUserAsync(int id, CreateUserDto request)
    {
        HttpResponseMessage httpResponseMessage = await client.PutAsJsonAsync($"User/{id}", request);
        string response = await httpResponseMessage.Content.ReadAsStringAsync();
           if (!httpResponseMessage.IsSuccessStatusCode)
        {
            throw new Exception(response);
        }
    }
}
