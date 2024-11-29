using Advent_of_Code.Models;

namespace Advent_of_Code._2015;
internal class Day2 : IDay
{
    public int Year { get; init; } = 2015;
    public int Day { get; init;  } = 2;
    List<Box> boxes = [];
    public string Part1()
    {
        double wrappingPaperNeeded = 0;
        foreach (Box box in boxes)
        {
            wrappingPaperNeeded += box.GetSurfaceArea();
            var smallesSide = box.XY.GetSurfaceArea();
            if(box.XZ.GetSurfaceArea() < smallesSide) smallesSide = box.XZ.GetSurfaceArea();
            if (box.YZ.GetSurfaceArea() < smallesSide) smallesSide = box.YZ.GetSurfaceArea();
            wrappingPaperNeeded += smallesSide;
        }
        return wrappingPaperNeeded.ToString();
    }

    public string Part2()
    {
        double count = 0;
        foreach (var box in boxes)
        {
            count += box.GetVolume();
            count += GetSmallestFaceCircumfrence(box);
        }

        return count.ToString();
    }

    public void Setup(string task)
    {
        boxes = task.Split('\n')
            .Select(line =>
            {
                var values = line.Split('x');
                return new Box(double.Parse(values[0]), double.Parse(values[1]), double.Parse(values[2]));
            }).ToList();
    }

    private static double GetSmallestFaceCircumfrence(Box box)
    {
        var smallestCircumfrence = box.XY.GetCircumfrence();
        var otherCircumfrence = box.XZ.GetCircumfrence();

        if (smallestCircumfrence > otherCircumfrence)
        {
            smallestCircumfrence = otherCircumfrence;
        }
        
        otherCircumfrence = box.YZ.GetCircumfrence();

        if (smallestCircumfrence > otherCircumfrence)
        {
            smallestCircumfrence = otherCircumfrence;
        }
        
        return smallestCircumfrence;
    }
}
