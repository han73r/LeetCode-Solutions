using System.Collections.Generic;

public class Solution
{
    public IList<IList<int>> FindWinners(int[][] matches)
    {
        HashSet<int> zeroLoss = new HashSet<int>();
        HashSet<int> oneLoss = new HashSet<int>();
        HashSet<int> moreLoss = new HashSet<int>();

        foreach (var match in matches)
        {
            int winner = match[0];
            int loser = match[1];

            // Add winner.
            if (!oneLoss.Contains(winner) && !moreLoss.Contains(winner))
            {
                zeroLoss.Add(winner);
            }

            // Add or move loser.
            if (zeroLoss.Contains(loser))
            {
                zeroLoss.Remove(loser);
                oneLoss.Add(loser);
            }
            else if (oneLoss.Contains(loser))
            {
                oneLoss.Remove(loser);
                moreLoss.Add(loser);
            }
            else if (moreLoss.Contains(loser))
            {
                continue;
            }
            else
            {
                oneLoss.Add(loser);
            }
        }

        int[][] answer = new int[2][];
        answer[0] = zeroLoss.OrderBy(x => x).ToArray();
        answer[1] = oneLoss.OrderBy(x => x).ToArray();

        return answer;
    }
}