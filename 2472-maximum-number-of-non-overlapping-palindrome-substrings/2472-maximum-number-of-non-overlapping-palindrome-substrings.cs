public class Solution {
    private bool IsPalindrome(ReadOnlySpan<char> span) {
        int left = 0;
        int right = span.Length - 1;

        while (left < right) {
            if (span[left++] != span[right--]) {
                return false;
            }
        }

        return true;
    }

    public int MaxPalindromes(string s, int k) {
        int n = s.Length;
        int count = 0;
        int i = 0;

        while (n - i >= k) {
            if (IsPalindrome(s.AsSpan(i, k))) {
                count++;
                i += k;
            }
            else if (n - i >= k + 1 && IsPalindrome(s.AsSpan(i, k + 1))) {
                count++;
                i += k + 1;
            }
            else {
                i++;
            }
        }
    
        return count;
    }
}
