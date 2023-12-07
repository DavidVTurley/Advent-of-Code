using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code._2023.Day1;
internal class Day2 : BaseDay
{
    public override int Year => 2023;

    public override int Day => 2;

    public override string Part1(string task)
    {
        var games = ParseTaskText(task);

        int total = 0;

        foreach (var game in games) 
        {
            if (game.HighestColourSeen[ColourEnum.Red] <= 12 ||
                game.HighestColourSeen[ColourEnum.Green] <= 13 ||
                game.HighestColourSeen[ColourEnum.Blue] <= 14)
            {
                total += game.GameNr;
            }
        }

        return total.ToString();
    }

    public override string Part2(string task)
    {
        throw new NotImplementedException();
    }

    private class Game
    {
        public int GameNr;
        public List<List<Colour>> Sets { get; } = [];

        public Dictionary<ColourEnum, int> HighestColourSeen = [];

        public void AddSet(List<Colour> colours)
        {
            Sets.Add(colours);
            foreach (Colour item in colours)
            {
                if (!HighestColourSeen.TryAdd(item.SetColour, item.Amount))
                {
                    if(HighestColourSeen[item.SetColour] < item.Amount)
                    {
                        HighestColourSeen[item.SetColour] = item.Amount;
                    }
                }
            }
        }

    }

    private struct Colour
    {
        public int Amount;
        public ColourEnum SetColour;

        public Colour(int amount, ColourEnum colour)
        {
            
        }

        
    }

    public enum ColourEnum
    {
        Red = 0,
        Green = 1,
        Blue = 2,
    }

    private List<Game> ParseTaskText(string text)
    {
        string[] gamesText = text.Split('\n');
        List<Game> games = new List<Game>();

        foreach (string gameString in gamesText)
        {
            if (string.IsNullOrEmpty(gameString)) continue;
            string[] textMod = gameString.Trim().Split(": ");
            Game game = new Game()
            {
                GameNr = int.Parse(
                textMod[0].Remove(0, 5).Replace(": ", "")),
            };

            textMod = textMod[1].Split("; ");

            foreach (string set in textMod)
            {
                string[] coloursStrings = set.Split(", ");
                List<Colour> colours = new List<Colour>();
                foreach (string colour in coloursStrings)
                {
                    colours.Add(new Colour()
                    {
                        Amount = int.Parse(colour[0].ToString()),
                        SetColour = Enum.Parse<ColourEnum>(colour.Substring(2), true)
                    });
                }

                game.AddSet(colours);
            }

            games.Add(game);
        }
        return games;
    }
}
