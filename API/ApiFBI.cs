using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

class ApiFBI
{ //Chamou a api para obtenção de dados que foram inseridos manualmente no BD
    static async Task CallApi()
    {
        string baseUrl = "https://api.fbi.gov/wanted/v1/list?min-reward=50000&page=";
        List<JToken> allItems = new List<JToken>();



        for (int page = 1; page <= 48; page++)
        {
            string url = baseUrl + page;
            JArray items = await FetchData(url);
            allItems.AddRange(items);


        }

        // Exibe o resultado final
        JArray finalResult = new JArray(allItems);
        Console.WriteLine(finalResult.ToString());
        Console.ReadLine();
    }

    static async Task<JArray> FetchData(string url)
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(responseBody);
                JArray items = (JArray)json["items"];
                return items;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Error: {e.Message}");
                return null;
            }
        }
    }

}