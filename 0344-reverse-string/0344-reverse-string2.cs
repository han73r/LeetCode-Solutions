public class Solution {
    public void ReverseString(char[] s) {
        int start = 0;                      // O(1)
        int end = s.Length - 1;             // O(1)
        while (start < end) {
            s[start] ^= s[end];
            s[end] ^= s[start];
            s[start] ^= s[end];
            start++;
            end--;
        }
    }
}