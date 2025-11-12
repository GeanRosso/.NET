using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Text.Json;
using ApiContracts.UserFolder;
using Microsoft.AspNetCore.Components.Authorization;
using ApiContracts;

namespace BlazorApp.Auth;

public class SimpleAuthProvider : AuthenticationStateProvider
{
    private readonly HttpClient httpClient;
    private ClaimsPrincipal? currentClaimsPrincipal;
    public SimpleAuthProvider(HttpClient httpClient) { this.httpClient = httpClient; }

    public string errorMessage { get; private set; }

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
         => Task.FromResult(new AuthenticationState(currentClaimsPrincipal ?? new()));

    public async Task Login(string userName, int password)
    {
       HttpResponseMessage response = await httpClient.PostAsJsonAsync(
            "Auth",
            new LoginRequest(userName, password));
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
             var body = await response.Content.ReadAsStringAsync();
            errorMessage = $"Login failed: {(int)response.StatusCode} {response.StatusCode} - {body}";
            return;
        }
        UserDto userDto = JsonSerializer.Deserialize<UserDto>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;

        List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, userDto.Username),
            new Claim("Id", userDto.Id.ToString()),
        };
        ClaimsIdentity identity = new ClaimsIdentity(claims, "apiauth");

        currentClaimsPrincipal = new ClaimsPrincipal(identity);
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(currentClaimsPrincipal)));

    }
 public void Logout()
    {
        currentClaimsPrincipal = new();
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(currentClaimsPrincipal))); 
    }
    } 
    