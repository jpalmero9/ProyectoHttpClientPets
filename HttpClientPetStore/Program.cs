
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace HttpClientPetStore
{
    internal static class Program
    {
        static async Task Main(string[] args)
        {
            string urlDestino = $"https://petstore.swagger.io/v2/pet";
            string elId = "0";
            string nombrePet = "";
            string laPeticion = "";

            Console.WriteLine("Indique el nombre de su mascota:");
            nombrePet = Console.ReadLine();

            laPeticion = "{\"id\": \"" + elId + "\", \"name\": \"" + nombrePet + "\" }";
            
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var content = new StringContent(laPeticion, System.Text.Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(urlDestino, content);

                    if (response.IsSuccessStatusCode)
                    {                       
                        string responseBody = await response.Content.ReadAsStringAsync();
                        
                        Console.WriteLine();
                        Console.WriteLine("Resultado de su transacción:");
                        Console.WriteLine("----------------------------");                        
                        Console.WriteLine(JsonConvert.DeserializeObject(responseBody));
                        Console.WriteLine("----------------------------");
                        Console.WriteLine("Presione enter para finalizar");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Error en la petición: " + response.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
