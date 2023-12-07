using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code;
public abstract class BaseDay : IDay
{
    public abstract int Year { get; }
    public abstract int Day { get; }

    public void Setup()
    {

    }

    public abstract string Part1(string task);

    public abstract string Part2(string task);
}
