public class Solution 
{
    public int StrStr(string haystack, string needle)
    {
        int index = -1;
        if (needle.Length > haystack.Length)
        {
            return index;
        }

        int j = 0;
        int startIndex = -1;

        for (int i = 0; i < haystack.Length; i++)
        {
            if (haystack[i] == needle[j])
            {
                if (startIndex == -1)
                {
                    startIndex = i;
                }

                if (j == needle.Length - 1)
                {
                    index = startIndex;
                    break;
                }

                j++;
            }
            else
            {
                if (startIndex != -1)
                {
                    i = startIndex;
                }
                j = 0;
                startIndex = -1;
            }
        }
        return index;
    }
}