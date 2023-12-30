using System.Collections.Generic;

public class Solution
{
    public bool MakeEqual(string[] words)
    {
        var letters = new Dictionary<char, int>();
        int length = words.Length;

        foreach (string word in words)
        {
            foreach (char ch in word)
            {
                if (letters.ContainsKey(ch))
                    letters[ch]++;
                else
                    letters.Add(ch, 1);
            }
        }
        foreach (var kvp in letters)
        {
            if (kvp.Value % length != 0)
                return false;

        }
        return true;
    }
}