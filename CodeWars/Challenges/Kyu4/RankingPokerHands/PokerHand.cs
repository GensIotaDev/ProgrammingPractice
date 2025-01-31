namespace Challenges.Kyu4.RankingPokerHands;

using System;
using System.Collections.Generic;
using System.Linq;

public enum Result 
{ 
    Win, 
    Loss, 
    Tie 
}

enum HandOutcome
{
    High = 0,
    Pair,
    TwoPair,
    ThreeKind,
    Straight,
    Flush,
    FullHouse,
    FourKind,
    StraightFlush,
    RoyalFlush
}

struct Card : IEquatable<Card>
 {
     public int value; //0-12 (2-A)
     public char suit;

     public Card(char value, char suit)
     {
         this.value = value switch
         {
             >= '2' and <= '9' => value - '2',
             'T' => 8,
             'J' => 9,
             'Q' => 10,
             'K' => 11,
             'A' => 12,
             _ => throw new ArgumentException($"Incompatible card value: {value}")
         };

         this.suit = suit;
     }

     public bool Equals(Card other)
     {
         return value == other.value && suit == other.suit;
     }

     public override bool Equals(object obj)
     {
         return obj is Card other && Equals(other);
     }

     public override int GetHashCode()
     {
         return HashCode.Combine(value, suit);
     }
 }

/// <summary>
/// For this <see href="https://www.codewars.com/kata/5739174624fc28e188000465">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/5739193292d15170d40000b2/groups/62bc8e5c21a55f000134af8a">here</see>
/// </summary>
public class PokerHand
{
    private HandOutcome _handType;
    private readonly List<Card> _referenceCards;
    public PokerHand(string hand)
    {
        _referenceCards = new List<Card>();
        
        var cards = new Card[5];
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i] = new Card(hand[3 * i], hand[(3 * i) + 1]);
        }

        Array.Sort(cards, (card, card1) => card.value.CompareTo(card1.value));
        
        CalculateHand(cards);
    }
    
    public Result CompareWith(PokerHand hand)
    {
        if (this._handType > hand._handType)
            return Result.Win;
        if (this._handType < hand._handType)
            return Result.Loss;
        
        //assume same types have same reference lengths
        for (int i = 0; i < this._referenceCards.Count; i++)
        {
            if (this._referenceCards[i].value > hand._referenceCards[i].value)
                return Result.Win;
            if (this._referenceCards[i].value < hand._referenceCards[i].value)
                return Result.Loss;
        }

        return Result.Tie;
    }

    private void CalculateHand(Card[] cards)
    {
        var groups = cards.GroupBy(c => c.value,
            (key, values) => new
            {
                Key = key,
                Count = values.Count()
            }).Where(q => q.Count > 1).ToList();

        //detect groups, these are exclusive from straight or flush so early exit
        var gCount = groups.Count;
        switch (gCount)
        {
            case 1:
            {
                var g = groups.Single();
                _handType = g.Count switch
                {
                    2 => HandOutcome.Pair,
                    3 => HandOutcome.ThreeKind,
                    4 => HandOutcome.FourKind,
                    _ => throw new ArgumentException("Cheating detected!")
                };
            
                _referenceCards.Add(new Card()
                {
                    value = g.Key,
                    suit = 'R'
                });

                foreach (var i in cards.Where(c => c.value != g.Key).Reverse())
                {
                    _referenceCards.Add(new Card()
                    {
                        value = i.value,
                        suit = 'R'
                    });
                }
                
                return;
            }
            case 2:
            {
                var largest = groups.MaxBy(m => m.Count);

                _handType = largest!.Count switch
                {
                    2 => HandOutcome.TwoPair,
                    3 => HandOutcome.FullHouse,
                    _ => throw new ArgumentException("Cheating detected!")
                };
            
                _referenceCards.Add(new Card()
                {
                    value = largest.Key,
                    suit = 'R'
                });
                groups.Remove(largest);
                var smaller = groups.Single();
                _referenceCards.Add(new Card()
                {
                    value = smaller.Key,
                    suit = 'R'
                });
              
                foreach (var i in cards.Where(c => c.value != largest.Key || c.value != smaller.Key).Reverse())
                {
                    _referenceCards.Add(new Card()
                    {
                        value = i.value,
                        suit = 'R'
                    });
                }
                
                return;
            }
        }
        
        var isFlush = cards.All(c => c.suit == cards[0].suit);

        bool isStraight = true;
        for (int i = 1; i < cards.Length; i++)
        {
            if (cards[i].value != cards[i - 1].value + 1)
            {
                isStraight = false;
                break;
            }
        }

        if (isFlush && isStraight)
        {
            _handType = (cards[0].value == 8) ? HandOutcome.RoyalFlush : HandOutcome.StraightFlush;
        }
        else if (isFlush)
        {
            _handType = HandOutcome.Flush;
        }
        else if (isStraight)
        {
            _handType = HandOutcome.Straight;
        }
        else
        {
            _handType = HandOutcome.High;
        }

        for(var i = cards.Length; i > 0; i--)
        {
            _referenceCards.Add(new Card()
            {
                value = cards[i - 1].value,
                suit = 'R'
            });
        }
    }
}