public class Solution 
{
    public bool IsIsomorphic(string s, string t)
        {
        if (s.Length != t.Length)
        {
            return false;
        }
        var st = new Dictionary<char, char>();

        for (int i = 0; i < s.Length; i++)
        {
            if (st.ContainsKey(s[i]))
            {
                if (st[s[i]] != t[i])
                {
                    return false;
                }              
            }
            else
            {
                if (TryToFoundValue(st, t[i]))
                {
                    return false;
                }
                st.Add(s[i], t[i]);
            }
        }
        return true;
    }

    private bool TryToFoundValue(Dictionary<char, char> dict, char value)
    {
        foreach (var pair in dict)
        {
            if (pair.Value == value)
            {
                return true;
            }
        }
        return false;
    }
}