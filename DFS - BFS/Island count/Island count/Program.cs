public class Program
{
    public static void Main(string[] args)
    {
        string[][] grid =
        {
            new string[] {"W", "L", "W", "W", "L"},
            new string[] {"W", "L", "W", "W", "L"},
            new string[] {"W", "W", "W", "L", "W"},
            new string[] {"W", "W", "L", "L", "W"},
            new string[] {"L", "W", "W", "L", "L"},
            new string[] {"L", "L", "W", "W", "W"},
        };
        Console.WriteLine("The total number of island is: " + CountIsland(grid)); // return 4
    }

    private static int CountIsland(string[][] grid)
    {
        int count = 0;
        List<string> visited = new();

        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (FindIsland(grid, i, j, visited))
                    count++;
            }
        }

        return count;
    }

    private static bool FindIsland(string[][] grid, int row, int col, List<string> visited)
    {
        if (visited.Contains(row + "," + col) || grid[row][col].ToUpper().Equals("W"))
            return false;

        visited.Add(row + "," + col);

        while (col > 0)
            if (!FindIsland(grid, row, col - 1, visited))
                break;
        while (col < grid[row].Length - 1)
            if (!FindIsland(grid, row, col + 1, visited))
                break;
        while (row < grid.Length - 1 && col < grid[row].Length) // check if there is an actually column in the next row
            if (!FindIsland(grid, row + 1, col, visited))
                break;

        return true;
    }
}