using Advent_of_Code;

// Get the session code from the Network tab in your browser. It should be in the first message sent

var client = new ConnectionClient("_ga=GA1.2.1378848460.1731953808; _ga_MHSNPJKWC7=GS1.2.1732464456.2.1.1732464868.0.0.0; session=53616c7465645f5f9bb2108d2c274726ba428350d67d3fa284f2a969150e0b57846e856990a99053d1e9f5f345847873eddf19d266825a2daeb2bc1a47cd4f25; _gid=GA1.2.1226660345.1732464456; _gat=1");








IDay day = new Advent_of_Code._2015.Day1();


String challengeText = await client.GetChallengeTextAsync(day);

day.Setup(challengeText);

string awnser1 = day.Part1();
Console.WriteLine("Awnser 1: " + awnser1 );


string awnser2 = day.Part2();
Console.WriteLine("Awnser 2: " + awnser2 );

var stop = "";

