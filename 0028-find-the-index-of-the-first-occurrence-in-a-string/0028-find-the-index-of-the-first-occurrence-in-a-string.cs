public class Solution 
{
    public int StrStr(string haystack, string needle)
    {
        int hayLen = haystack.Length;
        int needleLen = needle.Length;
        if (needleLen == 0) { return -1; }
        if (needleLen > hayLen) { return -1; }

        for (int i = 0; i <= hayLen - needleLen; i++)
        {
            int j;
            for (j = 0; j < needleLen; j++)
            {
                if (haystack[i + j] != needle[j])
                {
                    break;
                }
            }
            if (j == needleLen)
            {
                return i;
            }
        }
        return -1;
    }
}