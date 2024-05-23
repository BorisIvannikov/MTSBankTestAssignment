using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTSBankTestAssignment
{
    internal static class HttpsProcessor
    {
        private static readonly HttpClient _client = new HttpClient();
        private static readonly Uri _url = new Uri("https://httpbin.org/post");

        public static async Task<(string, int)> SendPostRequestAsync(StringBuilder data)
        {
            try
            {
                var content = new StringContent(data.ToString(),Encoding.UTF8, "application/x-www-form-urlencoded");

                var response = await _client.PostAsync(_url, content);

                var responseBody = await response.Content.ReadAsStringAsync(); ;
                var statusCode = (int)response.StatusCode;

                return (responseBody, statusCode);
            }
            catch(Exception ex) 
            {                
                throw new Exception("Ошибка Post запроса");
            }
        }

    }
}
