using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorEcommerce.Client.Misc;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly ILocalStorageService _localStorageService;
    private readonly HttpClient _http;

    public CustomAuthenticationStateProvider(
        ILocalStorageService localStorageService,
        HttpClient http
    )
    {
        _localStorageService = localStorageService;
        _http = http;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var authenticationToken = await _localStorageService.GetItemAsStringAsync(
            "authenticationToken"
        );
        var identity = new ClaimsIdentity();
        _http.DefaultRequestHeaders.Authorization = null;

        if (!string.IsNullOrEmpty(authenticationToken))
        {
            try
            {
                identity = new ClaimsIdentity(ParseClaimsFromJwt(authenticationToken), "jwt");
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Bearer",
                    authenticationToken.Replace("\"", "")
                );
            }
            catch
            {
                await _localStorageService.RemoveItemAsync("authenticationToken");
                identity = new ClaimsIdentity();
            }
        }

        var user = new ClaimsPrincipal(identity);
        var state = new AuthenticationState(user);

        NotifyAuthenticationStateChanged(Task.FromResult(state));

        return state;
    }

    private IEnumerable<Claim>? ParseClaimsFromJwt(string jwt)
    {
        var payload = jwt.Split('.')[1];
        var jsonBytes = ParseBase64WithoutPadding(payload);
        var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
        var claims = keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));

        return claims;
    }

    private byte[] ParseBase64WithoutPadding(string base64)
    {
        switch (base64.Length % 4)
        {
            case 2:
                base64 += "==";
                break;
            case 3:
                base64 += "=";
                break;
        }

        return Convert.FromBase64String(base64);
    }
}
