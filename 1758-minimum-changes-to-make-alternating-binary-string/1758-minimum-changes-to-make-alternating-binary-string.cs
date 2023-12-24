using System;

public class Solution
{
    public int MinOperations(string s)
    {
        int countFromZero = 0;
        int countFromOne = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] != (i % 2 == 0 ? '0' : '1'))
            {
                countFromZero++;
            }
            else
            {
                countFromOne++;
            }
        }

        return Math.Min(countFromZero, countFromOne);
    }
}