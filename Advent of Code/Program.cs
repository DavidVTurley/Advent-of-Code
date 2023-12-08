using Advent_of_Code;
using Advent_of_Code._2023.Day1;
using System.Net.Http.Json;

IDay day = new Day2();

String challengeText = await GetChallengeTextAsync();

string awnser1 = day.Part1(challengeText);
Console.WriteLine("Awnser 1: " + awnser1 );

string awnser2 = day.Part2(challengeText);
Console.WriteLine("Awnser 2: " + awnser2 );

var stop = "";

async Task<string> GetChallengeTextAsync()
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
        String sessionCookie = "53616c7465645f5f62eb1bf72c1455b6e7fd41d88352b839481deef27ab0039ab775d5a4e190327268968907c2e005d180181c83e83c3a9e854f3cfb87108c99";
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(@"https://adventofcode.com/");
        client.DefaultRequestHeaders.Add("Cookie", $"session={sessionCookie}");

        HttpResponseMessage response = await client.GetAsync($"{day.Year}/day/{day.Day}/input");
        challengeText = (await response.Content.ReadAsStringAsync()).Trim();

        File.WriteAllText(filePath, challengeText);
    }

    return challengeText;
}