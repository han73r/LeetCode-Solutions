public class Solution 
    {
    public int StrStr(string haystack, string needle) 
    {
        if (needle.Length == 0) { return -1; }
        if (needle.Length > haystack.Length) { return -1; }

        if(haystack.Contains(needle))
        {
            for(int i = 0;i<haystack.Length;i++)
            {
                if(haystack[i..(needle.Length+i)] == needle)
                {
                    return i;
                }
            }
            return 0;
        }
        else
        {
            return -1;
        }
    }
}
