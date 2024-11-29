namespace Advent_of_Code._2023;
public class Day3 : BaseDay
{
    public override int Year { get; init; } = 2023;
    public override int Day { get; init; } = 3;


    public override string Part1()
    {
        throw new NotImplementedException();
    }

    public override string Part2()
    {
        throw new NotImplementedException();
    }

    public override void Setup(string task)
    {
        string[] rows = task.Split('\n');


        for (int rowIndex = 0; rowIndex < rows.Length-1; rowIndex++) 
        {
            string row = rows[rowIndex];

            for (int columnIndex = row.Length-1; columnIndex >= 0 ; columnIndex--)
            {
                char cell = row[columnIndex];
                if(char.IsDigit(cell))
                {
                    // Check right top/mid/bottom
                    FindPartNumber(rows, rowIndex, columnIndex);
                    //check own top/mid/bottom
                    // if left is number go to step 2

                    //check left top/mid/bottom
                }
            }
        }
    }
    
    private (bool isPartNumber, int offset) FindPartNumber(string[] rows, int rowIndex, int colIndex) 
    {
        int offset = -1;

        

        
        return (true, offset);
    }
}
