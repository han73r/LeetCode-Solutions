public class Solution 
{
    public bool IsSubsequence(string s, string t) 
    {
        int j = 0;

        if (s.Length == 0)
        {
            return true;
        }

        for (int i = 0; i < t.Length; i++)
        {
            if (s[j] == t[i])
            {                 
                if (++j == s.Length)
                {
                    return true;
                }
            }
        }
        return false;        
    }
}
