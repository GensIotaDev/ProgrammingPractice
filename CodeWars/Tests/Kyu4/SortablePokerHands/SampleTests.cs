using Challenges.Kyu4.SortablePokerHands;

namespace Tests.Kyu4.SortablePokerHands;

public class SampleTests
{
    [Fact]
    public void Valid()
    {
        // Arrange
        var expected = new List<PokerHand> {
            new PokerHand("KS AS TS QS JS"),
            new PokerHand("2H 3H 4H 5H 6H"),
            new PokerHand("AS AD AC AH JD"),
            new PokerHand("JS JD JC JH 3D"),
            new PokerHand("2S AH 2H AS AC"),
            new PokerHand("AS 3S 4S 8S 2S"),
            new PokerHand("2H 3H 5H 6H 7H"),
            new PokerHand("2S 3H 4H 5S 6C"),
            new PokerHand("2D AC 3H 4H 5S"),
            new PokerHand("AH AC 5H 6H AS"),
            new PokerHand("2S 2H 4H 5S 4C"),
            new PokerHand("AH AC 5H 6H 7S"),
            new PokerHand("AH AC 4H 6H 7S"),
            new PokerHand("2S AH 4H 5S KC"),
            new PokerHand("2S 3H 6H 7S 9C")
        };
        
        var random = new Random((int)DateTime.Now.Ticks);
        var actual = expected.OrderBy(x => random.Next()).ToList();
        // Act
        actual.Sort();
        // Assert
        for (var i = 0; i < expected.Count; i++)
        {
            //Console.WriteLine($"actual: {actual[i].Hand} [{actual[i].score}] - expected: {expected[i].Hand} [{expected[i].score}]");
            Assert.Equal(expected[i], actual[i]);
        }     
    }
    
    [Fact]
    public void Valid2()
    {
        var expected = new List<PokerHand>()
        {
            new PokerHand("JH AH TH KH QH"),
            new PokerHand("JH 9H TH KH QH"),
            new PokerHand("5C 6C 3C 7C 4C"),
            new PokerHand("2D 6D 3D 4D 5D"),
            new PokerHand("2C 3C AC 4C 5C"),
            new PokerHand("JC KH JS JD JH"),
            new PokerHand("JC 7H JS JD JH"),
            new PokerHand("JC 6H JS JD JH"),
            new PokerHand("KH KC 3S 3H 3D"),
            new PokerHand("2H 2C 3S 3H 3D"),
            new PokerHand("3D 2H 3H 2C 2D"),
            new PokerHand("JH 8H AH KH QH"),
            new PokerHand("4C 5C 9C 8C KC"),
            new PokerHand("3S 8S 9S 5S KS"),
            new PokerHand("8C 9C 5C 3C TC"),
            new PokerHand("QC KH TS JS AH"),
            new PokerHand("JS QS 9H TS KH"),
            new PokerHand("6S 8S 7S 5H 9H"),
            new PokerHand("3C 5C 4C 2C 6H"),
            new PokerHand("2C 3H AS 4S 5H"),
            new PokerHand("AC KH QH AH AS"),
            new PokerHand("7C 7S KH 2H 7H"),
            new PokerHand("7C 7S 3S 7H 5S"),
            new PokerHand("AS 3C KH AD KC"),
            new PokerHand("3C KH 5D 5S KC"),
            new PokerHand("5S 5D 2C KH KC"),
            new PokerHand("3H 4C 4H 3S 2H"),
            new PokerHand("AH 8S AH KC JH"),
            new PokerHand("KD 4S KD 3H 8S"),
            new PokerHand("KC 4H KS 2H 8D"),
            new PokerHand("QH 8H KD JH 8S"),
            new PokerHand("8C 4S KH JS 4D"),
            new PokerHand("KS 8D 4D 9S 4S"),
            new PokerHand("KD 6S 9D TH AD"),
            new PokerHand("TS KS 5S 9S AC"),
            new PokerHand("JH 8S TH AH QH"),
            new PokerHand("TC 8C 2S JH 6C"),
            new PokerHand("2D 6D 9D TH 7D"),
            new PokerHand("9D 8H 2C 6S 7H"),
            new PokerHand("4S 3H 2C 7S 5H")
        };
        
        var random = new Random((int)DateTime.Now.Ticks);
        var actual = expected.OrderBy(x => random.Next()).ToList();
        // Act
        actual.Sort();
        // Assert
        for (var i = 0; i < expected.Count; i++)
        {
            //Console.WriteLine($"actual: {actual[i].Hand} [{actual[i].score}] - expected: {expected[i].Hand} [{expected[i].score}]");
            Assert.Equal(expected[i], actual[i]);
        }     
    }
}