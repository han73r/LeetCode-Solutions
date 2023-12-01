public class Solution
{
    char a = 'a';

    public bool ArrayStringsAreEqual(string[] word1, string[] word2)
    {
        return (ConverStringToInt(word1) == ConverStringToInt(word2));
    }

    private int ConverStringToInt(string[] word)
    {
        int value = 0;
        foreach (string str in word)
        {
            foreach (char ch in str)
            {
                int charValue = ch - a;
                value = value * 10 + charValue;
            }
        }
        return value;
    }
}