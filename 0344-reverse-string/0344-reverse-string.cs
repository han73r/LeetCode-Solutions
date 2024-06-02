public class Solution {
    public void ReverseString(char[] s) {
        int start = 0;                      // O(1)
        int end = s.Length - 1;             // O(1)
        char temp;                          // O(1)
        while (start < end) {               // 0(n)
            temp = s[start];                // O(1) 
            s[start] = s[end];              // O(1)
            s[end] = temp;                  // O(1)
            start++;                        // O(1)
            end--;                          // O(1)
        }
    }
}