public class Solution
{
    public bool IsAnagram(string s, string t)
    {
        var sh = SortString(s);
        var th = SortString(t);
        return sh.SequenceEqual(th);
    }

    private char[] SortString(string s)
    {
        char[] ch = s.ToCharArray();
        Array.Sort(ch);
        return ch;
    }
}