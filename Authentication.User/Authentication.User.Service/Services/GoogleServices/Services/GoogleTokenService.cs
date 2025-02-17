using Authentication.User.Service.Services.GoogleServices.DataModels;
using Authentication.User.Service.Services.GoogleServices.Interfaces;
using Authentication.User.Service.ViewModels.Settings;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.User.Service.Services.GoogleServices.Services
{
    public class GoogleTokenService : IGoogleTokenService
    {
        private readonly HttpClient _httpClient;
        public readonly GoogleApiSetting _googleApiSetting;
        public GoogleTokenService(HttpClient httpClient, IOptions<GoogleApiSetting> googleApiSetting)
        {
            _httpClient = httpClient;
            _googleApiSetting = googleApiSetting.Value;
        }

        public async Task<TokenResponse> ExchangeCodeForTokenAsync(string code)
        {
            var tokenRequest = new
            {
                code = code,
                client_id = _googleApiSetting.ClientId,
                client_secret = _googleApiSetting.ClientSecret,
                redirect_uri = _googleApiSetting.RedirectUris
            };

            var response = await _httpClient.PostAsJsonAsync(_googleApiSetting.TokenUri, tokenRequest);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<TokenResponse>();
        }

        public async Task<GoogleProfile> GetUserInfoAsync(string accessToken)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://www.googleapis.com/oauth2/v3/userinfo");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<GoogleProfile>();
        }
    }
}

