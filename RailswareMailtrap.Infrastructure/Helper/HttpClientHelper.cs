using Newtonsoft.Json;
using RailswareMailtrap.Infrastructure.Helper.ExceptionHandler;
using System.Net.Http.Headers;
using System.Text;

namespace RailswareMailtrap.Infrastructure.Helper
{
    public static class HttpClientHelper
    {
        public static async Task<T> PostAsync<T>(string url, string json, string? bearerToken = null)
        {
            T? tData = default(T);

            using (HttpClient client = new HttpClient())
            {
                var requestContent = new StringContent(json, Encoding.UTF8, "application/json");

                if (!string.IsNullOrEmpty(bearerToken))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

                using (HttpResponseMessage response = await client.PostAsync(url, requestContent))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                        {
                            throw new UnauthorizedException("Token is not correct");
                        }
                        return tData;
                    }

                    using (HttpContent content = response.Content)
                    {
                        string serializedContent = await content.ReadAsStringAsync();

                        if (serializedContent == string.Empty)
                        {
                            return tData;
                        }

                        if (serializedContent != null)
                        {
                            tData = JsonConvert.DeserializeObject<T>(serializedContent) ?? throw new ArgumentNullException();
                            return tData;
                        }
                    }
                }
            }
            return tData;
        }
    }
}
