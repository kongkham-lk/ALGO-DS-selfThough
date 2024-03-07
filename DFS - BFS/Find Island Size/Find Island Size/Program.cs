using System;
using System.ComponentModel;

public class Program
{
    public static void Main(string[] args)
    {
        string[][] grid =
        {
            new string[] {"W", "L", "W", "W", "L"},
            new string[] {"W", "L", "W", "W", "L"},
            new string[] {"W", "L", "W", "L", "W"},
            new string[] {"W", "W", "L", "L", "W"},
            new string[] {"L", "W", "W", "L", "L"},
            new string[] {"L", "L", "W", "L", "W"},
        };

        int[] size = FindIslandSize(grid);

        Console.WriteLine("MIN. island size is: " + size[0]); // return 2
        Console.WriteLine("MAX. island size is: " + size[1]); // return 6
    }

    private static int[] FindIslandSize(string[][] grid)
    {
        int minSize = int.MaxValue;
        int maxSize = int.MinValue;
        List<string> visited = new();

        for (int row = 0; row < grid.Length; row++)
        {
            for (int col = 0; col < grid[row].Length; col++)
            {
                if (!visited.Contains(row + "," + col) && grid[row][col].ToUpper().Equals("L"))
                {
                    int newSize = FoundIsland(grid, row, col, visited);

                    if (newSize > 0) // land's size must greater than 0
                    {
                        minSize = Math.Min(minSize, newSize);
                        maxSize = Math.Max(maxSize, newSize);
                    }
                }
            }
        }
        return new int[] {minSize, maxSize};
    }

    private static int FoundIsland(string[][] grid, int row, int col, List<string> visited)
    {
        if (visited.Contains(row + "," + col) || !grid[row][col].ToUpper().Equals("L"))
            return 0;

        visited.Add(row + "," + col);
        int totalSize = 1;

        while (col > 0)
        {
            int size = FoundIsland(grid, row, col - 1, visited);
            if (size == 0)
                break;
            totalSize += size;
        }
        while (col < grid[row].Length - 1)
        {
            int size = FoundIsland(grid, row, col + 1, visited);
            if (size == 0)
                break;
            totalSize += size;
        }
        while (row < grid.Length - 1 && col < grid[row].Length)
        {
            int size = FoundIsland(grid, row + 1, col, visited);
            if (size == 0)
                break;
            totalSize += size;
        }

        return totalSize;
    }
}