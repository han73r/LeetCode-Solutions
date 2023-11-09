public class Solution 
{
    public int CountHomogenous(string s) 
    {
        const int Mod = 1000000007;
        long result = 0;
        int count = 1;

        for (int i = 1; i < s.Length; i++)
        {
            if (s[i] == s[i - 1])
            {
                count++;
            }
            else
            {
                result = (result + (long)count * (count + 1) / 2) % Mod;
                count = 1;
            }
        }
        result = (result + (long)count * (count + 1) / 2) % Mod;

        return (int)result;
    }
}