public class Solution {
    public string LongestCommonPrefix(string[] strs) 
    {
        string prefix = strs[0];
        for (int i = 1; i < strs.Length; i++)
        {
            string currentStr = strs[i];
            int j = 0;
            while (j < prefix.Length && j < currentStr.Length && prefix[j] == currentStr[j])
            {
                j++;
            }

            prefix = prefix.Substring(0, j);

            if (string.IsNullOrEmpty(prefix))
            {
                break;
            }
        }

        return prefix;    
    }
}