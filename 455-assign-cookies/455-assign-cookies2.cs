using System;

public class Solution
{
    public int FindContentChildren(int[] g, int[] s)
    {
        Array.Sort(g);
        Array.Sort(s);

        int contentChildren = 0, childIndex = 0, cookieIndex = 0;

        while (childIndex < g.Length && cookieIndex < s.Length)
        {
            if (s[cookieIndex] >= g[childIndex])
            {
                contentChildren++;
                childIndex++;
            }
            cookieIndex++;
        }
        return contentChildren;
    }
}