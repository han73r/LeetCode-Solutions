using System.Linq;

public class Solution
{
    private string vowels = "aeiou";

    public bool HalvesAreAlike(string s)
    {
        s = s.ToLower();
        int a = 0, b = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (vowels.Contains(s[i]))
            {
                if (i < s.Length / 2)
                    a++;
                else
                    b++;
            }
        }
        return (a == b);
    }
}