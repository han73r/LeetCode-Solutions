public class Solution 
{
    public string SortVowels(string s) 
    {
        List<char> vowels = new List<char>();

        foreach (char c in s)
        {
            if ("aeiouAEIOU".IndexOf(c) != -1)
            {
                vowels.Add(c);
            }
        }
        
        vowels.Sort();
        int vowelIndex = 0;
        char[] result = s.ToCharArray();

        for (int i = 0; i < s.Length; i++)
        {
            if ("aeiouAEIOU".IndexOf(s[i]) != -1)
            {
                result[i] = vowels[vowelIndex];
                vowelIndex++;
            }
        }
        return new string(result);
    }
}