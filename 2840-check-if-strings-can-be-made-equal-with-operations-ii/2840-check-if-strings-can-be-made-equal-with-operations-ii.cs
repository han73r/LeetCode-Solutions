public class Solution {
    private const int MaxOffset = 7;
    public bool CheckStrings(string s1, string s2) {
        int n = s1.Length;
        if (n != s2.Length) return false;
        int[] counts = new int[256];
        for (int index = 0; index < n; index++) {
            int offset = (index & 1) << MaxOffset;
            counts[offset + s1[index]]++;
            counts[offset + s2[index]]--;
        }
        foreach (int count in counts)
            if (count != 0) return false;
        return true;
    }
}
