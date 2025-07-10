namespace Challenges.Kyu4.SortablePokerHands;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/586423aa39c5abfcec0001e6">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/58645f8a4e2b97b0900008a7/groups/6812d55b772e2dd47824d6d0">here</see>
/// </summary>
public class PokerHand : IComparable<PokerHand>
{
    private double score;
    
    public PokerHand(string hand)
    {
        bool flush = CheckFlush(hand);
        bool straight = CheckStraight(hand, out char[] card);
        bool grouped = CheckGroups(hand, out (char card, int count)[] groups);
        
        score = 0.0;
        if (straight)
        {
            score = flush ? 9.0 : 5.0;          // Royal/Straight Flush or normal straight
            score += Priority(card[0]) / 14.0;  // distinction between Royal/Straight flush is only by (Ace) highcard
        }
        else
        {
            if (grouped)
            {
                score = groups switch
                {
                    [(_, 4), _] => 8.0,         // Four of a kind
                    [(_, 3), (_, 2)] => 7.0,    // Full house
                    [(_, 3), ..] => 4.0,        // Three of a kind
                    [(_, 2), (_, 2), _] => 3.0, // Two pair
                    [(_, 2), ..] => 2.0,        // One pair
                    _ => 1.0
                };
            }
            else
            {
                score = flush ? 6.0 : 1.0;      // Normal flush or Highcard
            }
            
            for (var i = 0; i < groups.Length; i++)
            {
                score += Priority(groups[i].card) / Math.Pow(14.0, i + 1); // proceeding groups or single cards decrease (weighted) importance
            }
        }
    }
    
    public int CompareTo(PokerHand other)
    {
        if (other is null) return -1;
        return -1 * score.CompareTo(other.score); //flip sorting order
    }

    private static bool CheckFlush(string hand)
    {
        char suit = hand[1];
        for (int i = 1; i < 5; i++)
        {
            if (suit != hand[3 * i + 1]) return false;
        }
        return true;
    }

    private static bool CheckStraight(string hand, out char[] sorted)
    {
        sorted = new char[5];
        for (int i = 0; i < 5; i++)
        {
            sorted[i] = hand[3 * i];
        }
        Array.Sort(sorted, (char c1, char c2) => -1 * Priority(c1).CompareTo(Priority(c2))); // Decending priority
        if (sorted is ['A', '5', '4', '3', '2']) //swap to Ace is low order
        {
            sorted = ['5', '4', '3', '2', 'A'];
            return true;
        }

        for (int i = 0; i < 4; i++)
        {
            if (Priority(sorted[i]) != Priority(sorted[i + 1]) + 1) return false;
        }
        
        return true;
    }

    private static bool CheckGroups(string hand, out (char card, int count)[] groups)
    {
        var arr = new char[5];
        for (int i = 0; i < 5; i++)
        {
            arr[i] = hand[3 * i];
        }

        groups = arr.GroupBy(x => x)
            .ToDictionary(x => x.Key, x => x.Count())   // Net9 - Countby 
            .OrderByDescending(p => p.Value)            
            .ThenByDescending(p => Priority(p.Key))
            .Select(p => (p.Key, p.Value))
            .ToArray();

        return groups.Length < 5; //only consider pairs or greater to be a group
    }

    private static int Priority(char c)
    {
        return c switch
        {
            'A' => 13,
            'K' => 12,
            'Q' => 11,
            'J' => 10,
            'T' => 9,
            _ => c - '2' + 1
        };
    }
}