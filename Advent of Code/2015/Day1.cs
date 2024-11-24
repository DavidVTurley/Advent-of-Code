using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code._2015;
internal class Day1 : IDay
{
    public int Year { get; } = 2015;
    public int Day { get; } = 1;

    private string _challengeText = string.Empty;

    public string Part1()
    {
        int count = 0;
        foreach (var c in _challengeText.AsSpan())
        {
            if (c.Equals('(')) count++;
            else if (c.Equals(')')) count--;
        }
        return count.ToString();
    }

    public string Part2()
    {
        int count = 0;
        for (int i = 0; i < _challengeText.Length; i++)
        {
            char c = _challengeText[i];
            if (c.Equals('('))
                count++;
            else if (c.Equals(')'))
                count--;

            if(count < 0) 
                return (i+1).ToString();
        }
        return "Error";
    }

    public void Setup(string task)
    {
        _challengeText = task;
    }


}
