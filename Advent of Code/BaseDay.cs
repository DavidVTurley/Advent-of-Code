namespace Advent_of_Code;
public abstract class BaseDay : IDay
{
    public abstract int Year { get; init; }
    public abstract int Day { get; init; }

    public abstract string Part1();
    public abstract string Part2();

    public abstract void Setup(string task);
}
