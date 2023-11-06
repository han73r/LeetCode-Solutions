public class Solution 
{
    public bool WordPattern(string pattern, string s) 
    {
        string[] words = s.Split(' ');

        if (pattern.Length != words.Length)
        {
            return false;
        }

        Dictionary<char, string> patternToWord = new Dictionary<char, string>();
        Dictionary<string, char> wordToPattern = new Dictionary<string, char>();

        for (int i = 0; i < pattern.Length; i++)
        {
            char p = pattern[i];
            string word = words[i];

            if (patternToWord.ContainsKey(p))
            {
                if (patternToWord[p] != word)
                {
                    return false;
                }
            }
            else
            {
                patternToWord[p] = word;
            }

            if (wordToPattern.ContainsKey(word))
            {
                if (wordToPattern[word] != p)
                {
                    return false;
                }
            }
            else
            {
                wordToPattern[word] = p;
            }
        }
        return true;
    }
}