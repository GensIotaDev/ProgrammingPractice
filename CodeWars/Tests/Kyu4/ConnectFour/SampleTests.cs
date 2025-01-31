using Kata = Challenges.Kyu4.ConnectFour.ConnectFour;

namespace Tests.Kyu4.ConnectFour;

public class SampleTests
{
    public static IEnumerable<object[]> BasicData = new[]
    {/*
        new object[]
        {
            new List<string>()
            {
                "A_Red",
                "B_Yellow",
                "A_Red",
                "B_Yellow",
                "A_Red",
                "B_Yellow",
                "G_Red",
                "B_Yellow"
            },
            "Yellow"
        },
        new object[]
        {
            new List<string>()
            {
                "C_Yellow",
                "E_Red",
                "G_Yellow",
                "B_Red",
                "D_Yellow",
                "B_Red",
                "B_Yellow",
                "G_Red",
                "C_Yellow",
                "C_Red",
                "D_Yellow",
                "F_Red",
                "E_Yellow",
                "A_Red",
                "A_Yellow",
                "G_Red",
                "A_Yellow",
                "F_Red",
                "F_Yellow",
                "D_Red",
                "B_Yellow",
                "E_Red",
                "D_Yellow",
                "A_Red",
                "G_Yellow",
                "D_Red",
                "D_Yellow",
                "C_Red"
            },
            "Yellow"
        },
        new object[]
        {
            new List<string>()
            {
                "A_Yellow",
                "B_Red",
                "B_Yellow",
                "C_Red",
                "G_Yellow",
                "C_Red",
                "C_Yellow",
                "D_Red",
                "G_Yellow",
                "D_Red",
                "G_Yellow",
                "D_Red",
                "F_Yellow",
                "E_Red",
                "D_Yellow"
            },
            "Red"
        },*/
        new object[]
        {
            new List<string>
            {
                "C_Yellow",
                "D_Red",
                "B_Yellow",
                "G_Red",
                "F_Yellow",
                "B_Red",
                "B_Yellow",
                "F_Red",
                "D_Yellow",
                "G_Red",
                "G_Yellow",
                "E_Red",
                "E_Yellow",
                "C_Red",
                "B_Yellow",
                "A_Red",
                "C_Yellow",
                "G_Red",
                "B_Yellow",
                "C_Red",
                "G_Yellow",
                "G_Red",
                "B_Yellow",
                "F_Red",
                "A_Yellow",
                "E_Red",
                "C_Yellow",
                "E_Red",
                "A_Yellow",
                "D_Red",
                "D_Yellow",
                "E_Red",
                "C_Yellow",
                "A_Red",
                "E_Yellow",
                "D_Red",
                "F_Yellow",
                "F_Red",
                "F_Yellow",
                "A_Red",
                "D_Yellow",
                "A_Red"
            },
            "Yellow"
        }
    };
    [Theory]
    [MemberData(nameof(BasicData))]
    public void Basic(List<string> plays, string expected)
    {
        Assert.Equal(expected, Kata.WhoIsWinner(plays));
    }
}