using Advent_of_Code;
using Advent_of_Code._2023.Day1;
using System.Net.Http.Json;

IDay day = new Day2();


String sessionCookie = "53616c7465645f5f62eb1bf72c1455b6e7fd41d88352b839481deef27ab0039ab775d5a4e190327268968907c2e005d180181c83e83c3a9e854f3cfb87108c99";

HttpClient client = new HttpClient();
client.BaseAddress = new Uri(@"https://adventofcode.com/");
client.DefaultRequestHeaders.Add("Cookie", $"session={sessionCookie}");

HttpResponseMessage response = await client.GetAsync($"{day.Year}/day/{day.Day}/input");

String challengeText = await response.Content.ReadAsStringAsync();


string awnser1 = day.Part1(challengeText);
Console.WriteLine("Awnser 1: " + awnser1 );


string awnser2 = day.Part2(challengeText);
Console.WriteLine("Awnser 2: " + awnser2 );