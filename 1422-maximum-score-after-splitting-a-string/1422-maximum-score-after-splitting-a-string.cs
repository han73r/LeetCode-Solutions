using System.Linq;
using System;

public class Solution
{
    public int MaxScore(string s)
    {
        int maxScore = 0;
        int currentScore = 0;
        int zeroCount = 0;
        int onesCount = s.Count(c => c == '1');

        for (int i = 0; i < s.Length - 1; i++)
        {
            if (s[i] == '0')
                zeroCount++;
            else
                onesCount--;
            currentScore = zeroCount + onesCount;
            maxScore = Math.Max(maxScore, currentScore);
        }

        return maxScore;
    }
}