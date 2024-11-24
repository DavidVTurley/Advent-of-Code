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
        string filePath = Path.Combine(Path.GetTempPath(), "AdventOfCode", $"{day.Year.ToString("00")}/{day.Day}.txt");

        if (File.Exists(filePath))
        {
            return File.ReadAllText(filePath);
        }

        HttpResponseMessage response = await client.GetAsync($"{day.Year}/day/{day.Day}/input");


        challengeText = (await response.Content.ReadAsStringAsync()).Trim();

        Directory.CreateDirectory(Path.GetDirectoryName(filePath));
        File.WriteAllText(filePath, challengeText);
        return challengeText;
    }
}
