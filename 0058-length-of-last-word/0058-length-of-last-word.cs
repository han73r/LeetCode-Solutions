public class Solution 
{
    public int LengthOfLastWord(string s) 
    {
        int output = 0;
        char empty = ' ';
        if (s.Length == output) { return output; }

        for (int i = s.Length - 1; i >= 0; i--)
        {
            if (s[i] == empty)
            {
                if (output != 0)
                {
                    break;
                }                
            }
            else
            {
                output++;
            }
        }
        return output;
    }
}