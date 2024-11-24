using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code;
internal class ConnectionClient
{
    String _sessionCookie = string.Empty;
    HttpClient client = new HttpClient();

    public ConnectionClient(string cookie)
    {
        _sessionCookie = cookie;
        client.BaseAddress = new Uri(@"https://adventofcode.com/");
        client.DefaultRequestHeaders.Add("Cookie", $"session={_sessionCookie}");
    }

    public async Task<string> GetChallengeTextAsync(IDay day)
    {
        String challengeText = "";
        string baseDirectory = Directory.GetCurrentDirectory();
        string filePath = baseDirectory + $"/task/{day.Year}/day {day.Day}.txt";

        if (!Directory.Exists(baseDirectory + "/task"))
        {
            Directory.CreateDirectory(baseDirectory + "/task");
        }
        if (!Directory.Exists(baseDirectory + $"/task/day {day.Year}"))
        {
            Directory.CreateDirectory(baseDirectory + $"/task/day {day.Year}");
        }

        if (File.Exists(filePath))
        {
            challengeText = File.ReadAllText(filePath);
        }
        else
        {


            HttpResponseMessage response = await client.GetAsync($"{day.Year}/day/{day.Day}/input");
            challengeText = (await response.Content.ReadAsStringAsync()).Trim();

            File.WriteAllText(filePath, challengeText);
        }

        return challengeText;
    }

    public async Task<object> SaveChallengeText(string challengeText)
    {
        StringContent content = new StringContent("level=1&awnswer=1231");
        var response = await client.PostAsync(($"/{day.Year}/day/{day.Day}/awnser"), content);
        return;
    }
}
