public class Solution {
    public int LongestPalindrome(string[] words) {
        var visited = new int[26, 26];
        int count = 0;
        foreach (var word in words) {
            int c1 = word[0] - 'a';
            int c2 = word[1] - 'a';
            if (visited[c2, c1] > 0) {
                count += 4;
                visited[c2, c1]--;
            } else {
                visited[c1, c2]++;
            }
        }
        for (int i = 0; i < 26; i++) {
            if (visited[i, i] > 0) {
                count += 2;
                break;
            }
        }
        return count;
    }
}
