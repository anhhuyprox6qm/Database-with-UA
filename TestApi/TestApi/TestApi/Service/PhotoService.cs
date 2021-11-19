using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestApi.Entities;

namespace TestApi.Service
{
    class PhotoService
    {
        private const string ApiBaseUrl = "https://jsonplaceholder.typicode.com";
        private const string ApiSongPath = "/photos";

        public async Task<List<Photo>> GetPhotoAsync()
        {

            List<Photo> result = new List<Photo>();
            try
            {
                HttpClient httpClient = new HttpClient();
                var requestConnection =
                    await httpClient.GetAsync(ApiBaseUrl + ApiSongPath);
                if (requestConnection.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    var content = await requestConnection.Content.ReadAsStringAsync();
                    result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Photo>>(content);
                    Console.WriteLine(content);
                    return result;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return result;
        }
    }
}
