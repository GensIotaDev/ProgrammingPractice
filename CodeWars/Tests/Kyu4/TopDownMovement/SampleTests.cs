using Challenges.Kyu4.TopDownMovement;

namespace Tests.Kyu4.TopDownMovement;

public class SampleTests
{
    private static void CheckEquality(PlayerMovement player, Direction direction, int x, int y)
    {
        player.Update();
        
        Assert.Equal(player.Direction, direction);
        Assert.Equal(player.Position, new Tile(x, y));
    }

    [Fact]
    public void BasicTest1()
    {
        var player = new PlayerMovement(0, 0);
        var TestEquality = (Direction direction, int x, int y) => CheckEquality(player, direction, x, y);
        Input.Clear();

        Press(Direction.Down);

        TestEquality(Direction.Down, 0, 0);
        TestEquality(Direction.Down, 0, -1);
        TestEquality(Direction.Down, 0, -2);

        Press(Direction.Left);
        Press(Direction.Right);

        TestEquality(Direction.Left, 0, -2);
        TestEquality(Direction.Left, -1, -2);

        Release(Direction.Left);

        TestEquality(Direction.Right, -1, -2);

        Release(Direction.Right);

        TestEquality(Direction.Down, -1, -2);
        TestEquality(Direction.Down, -1, -3);

        Release(Direction.Down);

        TestEquality(Direction.Down, -1, -3);
    }
    
    [Fact]
    public void AllKeysAtOnce()
    {
        var player = new PlayerMovement(0, 0);
        var TestEquality = (Direction direction, int x, int y) => CheckEquality(player, direction, x, y);
        
        Input.Clear();
        
        Press(Direction.Down);
        Press(Direction.Left);
        Press(Direction.Right);
        Press(Direction.Up);
        
        TestEquality(Direction.Up, 0, 0);
        TestEquality(Direction.Up, 0, 1);

        Release(Direction.Left);

        TestEquality(Direction.Up, 0, 2);

        Release(Direction.Up);

        TestEquality(Direction.Down, 0, 2);

        Release(Direction.Down);

        TestEquality(Direction.Right, 0, 2);
        TestEquality(Direction.Right, 1, 2);
        TestEquality(Direction.Right, 2, 2);

        Release(Direction.Right);

        TestEquality(Direction.Right, 2, 2);
    }
    
    private void Press(Direction dir) { Console.WriteLine("Pressed " + dir); Input.Press(dir); }
    private void Release(Direction dir) { Console.WriteLine("Released " + dir); Input.Release(dir); }
}