﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code._2023.Day1;
internal class Day2 : BaseDay
{
    public override int Year => 2023;

    public override int Day => 2;
    Dictionary<int, Dictionary<string, int>> games = [];
    Dictionary<int, Dictionary<string, int>> gamesSmallest = [];

    public override string Part1(string task)
    {
        ParseTask(task);

        int total = 0;
        for (int i = 0; i < games.Count; i++)
        {
            Dictionary<string, int> game = games[i+1];
            if (game["red"] <= 12 && game["green"] <= 13 && game["blue"] <= 14)
            {
                total += i + 1;
            }
        }

        return total.ToString();
    }

    public override string Part2(string task)
    {
        int total = 0;

        foreach (KeyValuePair<int, Dictionary<string, int>> game in games)
        {
            total += game.Value["red"] * game.Value["green"] * game.Value["blue"];
        }

        return total.ToString();
    }

    private void ParseTask(string task)
    {
        string[] gameString = task.Split('\n');
        foreach (string game in gameString)
        {
            if(string.IsNullOrEmpty(game)) continue;
            string[] temp = game.Split(": ");
            int gameNr = int.Parse(temp[0].Remove(0, 5));

            temp = temp[1].Split("; ");
            int nr = 0;
            Dictionary<string, int> biggestDict = new Dictionary<string, int>();
            Dictionary<string, int> smallestDict = new Dictionary<string, int>();

            foreach (var set in temp)
            {
                foreach (var colourSet in set.Split(", "))
                {
                    if (string.IsNullOrEmpty(colourSet)) continue;

                    string[] t = colourSet.Split(' ');

                    nr = int.Parse(t[0]);
                    if (biggestDict.TryGetValue(t[1], out int value))
                    {
                        if (nr > value)
                        {
                            biggestDict[t[1]] = nr;
                        }

                    }
                    else
                    {
                        biggestDict.Add(t[1], nr);
                    }
                }
            }

            games.Add(gameNr, biggestDict);
            gamesSmallest.Add(gameNr, smallestDict);
        }
    }

    //private class Game
    //{
    //    public int GameNr;
    //    public List<List<Colour>> Sets { get; } = [];

    //    public Dictionary<ColourEnum, int> HighestColourSeen = [];

    //    public void AddSet(List<Colour> colours)
    //    {
    //        Sets.Add(colours);
    //        foreach (Colour item in colours)
    //        {
    //            if (!HighestColourSeen.TryAdd(item.SetColour, item.Amount))
    //            {
    //                if(HighestColourSeen[item.SetColour] < item.Amount)
    //                {
    //                    HighestColourSeen[item.SetColour] = item.Amount;
    //                }
    //            }
    //        }
    //    }

    //}

    //private struct Colour
    //{
    //    public int Amount;
    //    public ColourEnum SetColour;

    //    public Colour(int amount, ColourEnum colour)
    //    {
            
    //    }

        
    //}

    //public enum ColourEnum
    //{
    //    Red = 0,
    //    Green = 1,
    //    Blue = 2,
    //}

    //private List<Game> ParseTaskText(string text)
    //{
    //    string[] gamesText = text.Split('\n');
    //    List<Game> games = new List<Game>();

    //    foreach (string gameString in gamesText)
    //    {
    //        if (string.IsNullOrEmpty(gameString)) continue;
    //        string[] textMod = gameString.Trim().Split(": ");
    //        Game game = new Game()
    //        {
    //            GameNr = int.Parse(
    //            textMod[0].Remove(0, 5).Replace(": ", "")),
    //        };

    //        textMod = textMod[1].Split("; ");

    //        foreach (string set in textMod)
    //        {
    //            string[] coloursStrings = set.Split(", ");
    //            List<Colour> colours = new List<Colour>();
    //            foreach (string colour in coloursStrings)
    //            {
    //                colours.Add(new Colour()
    //                {
    //                    Amount = int.Parse(colour[0].ToString()),
    //                    SetColour = Enum.Parse<ColourEnum>(colour.Substring(2), true)
    //                });
    //            }

    //            game.AddSet(colours);
    //        }

    //        games.Add(game);
    //    }
    //    return games;
    //}
}
