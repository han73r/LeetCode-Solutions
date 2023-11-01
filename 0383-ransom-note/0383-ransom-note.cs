public class Solution 
{
    public bool CanConstruct(string ransomNote, string magazine) 
    {
        if (magazine.Length < ransomNote.Length)
        {
            return false;
        }
        
        int k = 0;
        StringBuilder output = new StringBuilder(magazine);

        for (int i = 0; i < ransomNote.Length; i++)
        {
            for (int j = 0; j < output.Length; j++)
            {
                if (ransomNote[i] == output[j])
                {
                    output[j] = '-';
                    k++;
                    break;
                }               
            }
        }
        return k == ransomNote.Length;
    }
}