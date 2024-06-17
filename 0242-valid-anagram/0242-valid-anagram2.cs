public class Solution
{
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length) return false;

        int[] charCount = new int[26];

        foreach (char c in s)
        {
            charCount[c - 'a']++;
        }
        foreach (char c in t)
        {
            charCount[c - 'a']--;
            if (charCount[c - 'a'] < 0)
                return false;
        }
        return true;
    }
}