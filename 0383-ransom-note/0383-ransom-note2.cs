public class Solution 
{
    public bool CanConstruct(string ransomNote, string magazine) 
    {
        if (magazine.Length < ransomNote.Length)
        {
            return false;
        }
        
        int[] charCounts = new int[26];
        foreach (char c in magazine)
        {
            charCounts[c - 'a']++;
        }

        foreach (char c in ransomNote)
        {
            if (charCounts[c - 'a'] > 0)
            {
                charCounts[c - 'a']--;
            }
            else
            {
                return false;
            }
        }
        return true;
    }
}
