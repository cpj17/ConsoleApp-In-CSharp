string url = "https://jsonformatter.org/db74aa"; // Replace with the URL of your JSON data source

try
{
    string json = await GetJsonAsync(url);
    // Now you can parse the JSON data as needed
    Console.WriteLine(json);

    Console.Read();
}
catch (Exception ex)
{
    Console.WriteLine("An error occurred: " + ex.Message);
}

static async Task<string> GetJsonAsync(string url)
{
    using (HttpClient httpClient = new HttpClient())
    {
        HttpResponseMessage response = await httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }
        else
        {
            throw new Exception($"Failed to fetch data. Status code: {response.StatusCode}");
        }
    }
}