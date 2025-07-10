using Challenges.Kyu2.BlainTrain;

namespace Tests.Kyu2.BlainTrain;

public class SampleTests
{
    [Fact]
    public void Test1()
    {
        string track =
            "                                /------------\\             \n" +
            "/-------------\\                /             |             \n" +
            "|             |               /              S             \n" +
            "|             |              /               |             \n" +
            "|        /----+--------------+------\\        |\n" +
            "\\       /     |              |      |        |             \n" +
            " \\      |     \\              |      |        |             \n" +
            " |      |      \\-------------+------+--------+---\\         \n" +
            " |      |                    |      |        |   |         \n" +
            " \\------+--------------------+------/        /   |         \n" +
            "        |                    |              /    |         \n" +
            "        \\------S-------------+-------------/     |         \n" +
            "                             |                   |         \n" +
            "/-------------\\              |                   |         \n" +
            "|             |              |             /-----+----\\    \n" +
            "|             |              |             |     |     \\   \n" +
            "\\-------------+--------------+-----S-------+-----/      \\  \n" +
            "              |              |             |             \\ \n" +
            "              |              |             |             | \n" +
            "              |              \\-------------+-------------/ \n" +
            "              |                            |               \n" +
            "              \\----------------------------/               ";

        string aTrain = "Aaaa";
        int aTrainPos = 147;
        string bTrain = "Bbbbbbbbbbb";
        int bTrainPos = 288;
        int limit = 1000;
        
        int expected = 516;
        
        Assert.Equal(expected, Dinglemouse.TrainCrash(track, aTrain, aTrainPos, bTrain, bTrainPos, limit));
    } 
}