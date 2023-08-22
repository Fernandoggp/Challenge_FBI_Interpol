using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;


class ApiInterpol
{   //Chamou a api para obtenção de dados que foram inseridos manualmente no BD
    static async Task CallApi()
    {
        string baseUrl = "https://ws-public.interpol.int/notices/v1/red?page=";
        List<JToken> allItems = new List<JToken>();



        for (int page = 1; page <= 8; page++)
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