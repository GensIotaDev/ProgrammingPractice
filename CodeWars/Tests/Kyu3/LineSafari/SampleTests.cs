using Challenges.Kyu3.LineSafari;

namespace Tests.Kyu3.LineSafari;

public class SampleTests
{
    private static char[][] MakeGrid(string[] rows)
    {
        char[][] grid = new char[rows.Length][];
        for (var i = 0; i < rows.Length; i++)
        {
            grid[i] = rows[i].ToCharArray();
        }

        return grid;
    }

    [Fact]
    public void ExGood1()
    {
        var grid = MakeGrid([
            "           ",
            "X---------X",
            "           ",
            "           "
        ]);
        //Preloaded.ShowGrid(grid);
        Assert.True(Dinglemouse.Line(grid));
    }

    [Fact]
    public void ExGood2()
    {
        var grid = MakeGrid([
            "     ",
            "  X  ",
            "  |  ",
            "  |  ",
            "  X  "
        ]);
        //Preloaded.ShowGrid(grid);
        Assert.True(Dinglemouse.Line(grid));
    }
    
    [Fact]
    public void ExGood3()
    {
        var grid = MakeGrid([
            "                    ",
            "     +--------+     ",
            "  X--+        +--+  ",
            "                 |  ",
            "                 X  ",
            "                    "
        ]);
        //Preloaded.ShowGrid(grid);
        Assert.True(Dinglemouse.Line(grid));
    }
}