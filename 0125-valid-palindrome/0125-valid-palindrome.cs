using System.Linq;

public class Solution 
{
    public bool IsPalindrome(string s) 
    {
        if (s.Length == 1) { return true; }

        s = new string(s.Where(char.IsLetterOrDigit).Select(char.ToLower).ToArray());

        int i = 0;
        int j = s.Length - 1;

        while (i < j)
        {
            if (s[i] != s[j])
            {
                return false;
            }

            i++;
            j--;
        }
        return true;
    }
}