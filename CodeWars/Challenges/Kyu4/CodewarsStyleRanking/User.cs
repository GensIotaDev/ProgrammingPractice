namespace Challenges.Kyu4.CodewarsStyleRanking;

using System;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/51fda2d95d6efda45e00004e">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/5caf4efcede79d00013fb5b3/groups/6127ea72469cfc00012590b9">here</see>
/// </summary>
public class User
{
    public int rank {get; private set; }
    public int progress {get; private set; }
    private int totalProgress;
  
    public User()
    {
        this.rank = -8;
        this.progress = 0;
        this.totalProgress = 0;
    }
    public void incProgress(int rank)
    {
        if(rank > 8 || rank < -8 || rank == 0)
        {
            throw new ArgumentException("rank in incProgress(int rank) can only be within the range of -8 to 8 excluding 0.");
        }
    
        int diff = GetRankDifference(rank);
        int progress = ConvertRankDifferenceToProgress(diff);
    
        this.totalProgress = Math.Clamp(this.totalProgress + progress, 0, 1500);
        //
        int rankFromBottom = this.totalProgress / 100;
        this.rank = (rankFromBottom > 7)? rankFromBottom - 7 : -8 + rankFromBottom;
        this.progress = this.totalProgress % 100;    
    }
  
    private int ConvertRankDifferenceToProgress(int rankDifference)
    {
        int progress = 0;
        if(rankDifference == -1)
        {
            progress = 1;
        }
        else if(rankDifference == 0)
        {
            progress = 3;
        }
        else if(rankDifference < -1){}
        else
        {
            progress = 10 * rankDifference * rankDifference;
        }
    
        return progress;
    }
    private int GetRankDifference(int activityRank)
    {
        if((activityRank < 0 && this.rank < 0) ||
           (activityRank > 0 && this.rank > 0))
        {
            return activityRank - this.rank;
        }
        else
        {
            if(this.rank < 0)
            {
                return activityRank - (this.rank + 1);
            }
            else if(activityRank < 0)
            {
                return (activityRank + 1) - this.rank;
            }
            else
                throw new NotImplementedException();
        }
    }
}