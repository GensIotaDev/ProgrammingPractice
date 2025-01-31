using Challenges.Kyu4.SimplisticTCP_FSM;

namespace Tests.Kyu4.SimplisticTCP_FSM;

public class SampleTests
{
    [Theory]
    [InlineData("CLOSE_WAIT", "APP_ACTIVE_OPEN", "RCV_SYN_ACK", "RCV_FIN")]
    public void Basic(string expected, params string[] input)
    {
        Assert.Equal(expected, TCP.TraverseStates(input));
    }
}