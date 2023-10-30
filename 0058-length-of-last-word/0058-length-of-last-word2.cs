public class Solution 
{
    public int LengthOfLastWord(string s) 
    {
        int output = 0;    
        if (s.Length-1 <= output) return s.Length;
        
        for (int i = s.Length - 1; i >= 0; i--)
        {
            if (s[i] == ' ')
            {
                if (output > 0)
                {
                    return output;
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
