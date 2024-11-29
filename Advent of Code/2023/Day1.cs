using System.Text.RegularExpressions;

namespace Advent_of_Code._2023.Day1;
internal class Day1 : BaseDay
{
    public override int Year { get; init; } = 2023;
    public override int Day { get; init; } = 1;

    string[] _task;

    public override void Setup(string task)
    {
        _task = task.Split("\n");
    }

    private string[] lines = [];
 
    public override string Part1()
    {
        int total = 0;

        foreach (string line in lines)
        {
            foreach (char c in line)
            {
                if (char.IsDigit(c))
                {
                    total += int.Parse(c.ToString()) * 10;
                    break;
                }
            }
            for(int i = line.Length -1;  i >= 0; i--)
            {
                if (char.IsDigit(line[i]))
                {
                    total += int.Parse(line[i].ToString());
                    break;
                }
            }
        }

        return total.ToString();
    }

    public override string Part2()
    {
        int total = 0;
        string word = string.Empty;
        Regex regex = new Regex("1|2|3|4|5|6|7|8|9|one|two|three|four|five|six|seven|eight|nine");

        foreach (string line in lines)
        {
            if (line.Length == 0)
            {
                continue;
            }
            MatchCollection matches = regex.Matches(line);

            word = matches[0].Value;
            if (IsDigit(word))
            {
                total += int.Parse(word) * 10;
            }
            else
            {
                total += (int)Enum.Parse<Numbers>(word) * 10;
            }

            word = matches[matches.Count - 1].Value;
            if (IsDigit(word))
            {
                total += int.Parse(word);
            }
            else
            {
                total += (int)Enum.Parse<Numbers>(word);
            }
        }

        return total.ToString();
    }

    private Boolean IsDigit(string word)
    {
        if (word.Length > 1) return false;
        return char.IsDigit(word[0]);
    }

    private enum Numbers
    {
        zero = 0, one = 1, two = 2, three = 3, four = 4, five = 5, 
        six = 6, seven = 7, eight = 8, nine = 9,
    }
}
