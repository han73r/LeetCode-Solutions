public class Solution {
    public int MinimumLength(string s) {
        int left = 0;
        int right = s.Length - 1;
        char curChar;

        while (left < right) {
            curChar = s[left];
            if (s[right] != curChar) {
                break;
            }
            while (left < right && s[left] == curChar) {
                left++;
            }
            while (left <= right && s[right] == curChar) {
                right--;
            }
        }
        return right - left + 1;
    }
}