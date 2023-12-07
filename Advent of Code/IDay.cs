using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code;
public interface IDay
{
    public abstract int Year { get; }
    public abstract int Day { get; }


    public void Setup();

    public string Part1(string task);
    public string Part2(string task);
}
