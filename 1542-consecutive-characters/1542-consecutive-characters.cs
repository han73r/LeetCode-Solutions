public class Solution 
{
    public int MaxPower(string s) 
    {
        var count = 1;
        var maxCount = 1;

        for (int i = 1; i < s.Length; i++)
        {
            if (s[i] == s[i - 1])
            {
                count++;
            }
            else
            {
                maxCount = Math.Max(maxCount, count);
                count = 1;
            }
        }
        return Math.Max(maxCount, count);
    }
}