namespace Challenges.Kyu2.BlainTrain;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/59b47ff18bcb77a4d1000076">Kata</see>
/// Submission - WIP
/// </summary>
public class Dinglemouse
{
    public static int TrainCrash(string track, string aTrain, int aTrainPos, string bTrain, int bTrainPos, int limit)
    {
        Track map = Track.Build(track);

        //set trains
        Train a = new Train(aTrain, aTrainPos, map);
        Train b = new Train(bTrain, bTrainPos, map);

        /*for (var cycle = 0; cycle < limit; cycle++)
        {
            for (var i = 0; i < trains.Length; i++)
            {
                trains[i].Tick();
                if(trains)
            }
        }*/
{       return -1;}
    }
}