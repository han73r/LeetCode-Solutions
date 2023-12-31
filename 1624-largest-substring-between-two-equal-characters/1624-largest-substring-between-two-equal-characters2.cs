public class Solution
{
    public int MaxLengthBetweenEqualCharacters(string s)
    {
        int result = -1;
        if (s.Length == 1) return result;

        int[] lastIndex = new int[26];
        Array.Fill(lastIndex, -1);

        for (int i = 0; i < s.Length; i++)
        {
            char currentChar = s[i];
            int charIndex = currentChar - 'a';

            if (lastIndex[charIndex] != -1)
                result = Math.Max((i - (lastIndex[charIndex] + 1)), result);
            else
                lastIndex[charIndex] = i;
        }

        return result;
    }
}