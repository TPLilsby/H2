using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnWebside
{
    internal class HTTP : IRequest
    {
        public async Task MakeRequest(string path)
        {
            HttpClient httpClient = new HttpClient();

            using HttpResponseMessage response = await httpClient.GetAsync(path);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"{jsonResponse}\n");
        }
    }
}
