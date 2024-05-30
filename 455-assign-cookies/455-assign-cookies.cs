using System;

public int FindContentChildren(int[] g, int[] s)
{
    int content = 0;
    Array.Sort(g);
    Array.Sort(s);

    int i = 0;
    int j = 0;

    while (i < g.Length && j < s.Length)
    {
        if (g[i] <= s[j])
        {
            content++;
            i++;
        }
        j++;
    }

    return content;
}