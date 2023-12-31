public class Solution
{
    public int MaxLengthBetweenEqualCharacters(string s)
    {
        int result = -1;
        if (s.Length == 1) return result;

        var dict = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++)
        {
            if (dict.ContainsKey(s[i]))
                result = Math.Max((i - (dict[s[i]] + 1)), result);
            else
                dict.Add(s[i], i);
        }
        return result;
    }
}