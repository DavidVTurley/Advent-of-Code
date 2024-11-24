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


    public abstract string Part1();
    public abstract string Part2();

    public abstract void Setup(string task);
}
