public class Solution 
{
    public bool IsSubsequence(string s, string t) 
    {
        int j = 0;

        if (s.Length == 0)
        {
            return true;
        }
        else if (t.Length < s.Length)
        {
            return false;
        }
        else
        {
            for (int i = 0; i < t.Length; i++)
            {
                if (s[j] == t[i])
                {                 
                    if (j == s.Length - 1)
                    {
                        return true;
                    }
                    j++;
                }
            }
            return false;
        }
    }
}