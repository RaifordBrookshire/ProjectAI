using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ProjectAI.Api.Controllers;

public class ContentController : Controller
{
    private readonly HttpClient _httpClient;

    public ContentController()
    {
        _httpClient = new HttpClient();
    }
   
    [HttpPost("/content")]
    public async Task<IActionResult> GetAnswer(string prompt)
    {
        prompt = "Generate a 50 word email inviting a patient back to the dental office";
       
        var apiKey = "";  // sk - 39why97DehSi3VA0JWEMT3BlbkFJ0vG4yGDzKJCXZQsAJyWJ
		var model = "text-davinci-002";
        var url = $"https://api.openai.com/v1/engines/{model}/completions";

        var request = new
        {
            prompt = prompt,
            temperature = 0.7,
            max_tokens = 128
        };

         var json = JsonConvert.SerializeObject(request);
         var content = new StringContent(json, Encoding.UTF8, "application/json");

         _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
         var response =  _httpClient.PostAsync(url, content).Result;

         var responseJson = response.Content.ReadAsStringAsync().Result;
         var answer = JsonConvert.DeserializeObject<dynamic>(responseJson);
         var generatedAnswer = answer.choices[0].text;
         string result = generatedAnswer.ToString();
        return Ok(result);
    }

}