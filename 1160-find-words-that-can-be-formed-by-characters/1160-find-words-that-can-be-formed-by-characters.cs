public class Solution
{
    public int CountCharacters(string[] words, string chars)
    {
        int[] charCount = CountChars(chars);
        int result = 0;
        foreach (string word in words)
        {
            if (CanFormWord(word, charCount))
            {
                result += word.Length;
            }
        }
        return result;
    }

    private int[] CountChars(string chars)
    {
        int[] charCount = new int[26];
        foreach (char ch in chars)
        {
            charCount[ch - 'a']++;
        }
        return charCount;
    }

    private bool CanFormWord(string word, int[] charCount)
    {
        int[] wordCount = CountChars(word);
        for (int i = 0; i < 26; i++)
        {
            if (wordCount[i] > charCount[i])
            {
                return false;
            }
        }
        return true;
    }
}