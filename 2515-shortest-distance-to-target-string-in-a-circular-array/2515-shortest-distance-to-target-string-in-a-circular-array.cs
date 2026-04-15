public class Solution {
    public int ClosestTarget(string[] words, string target, int startIndex) {
        int left = startIndex, right = startIndex;
        int length = 0;
        int n = words.Length;
        while (words[left] != target && words[right] != target && length <= n / 2) {
            length++;
            left = left > 0 ? left - 1 : (left - 1 + n) % n;
            right = right < n - 1 ? right + 1 : (right + 1) % n;
        }
        return length > n / 2 ? -1 : length;
    }
}
