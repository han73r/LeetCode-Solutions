public class Solution {
    public int LongestBalanced(string s) {
        int n = s.Length, len = 0;
        for (int i = 0; i < n; i++) {
            int[] freq = new int[26];
            for (int j = i; j < n; j++) {
                freq[s[j] - 'a']++;
                int mini = int.MaxValue, maxi = 0;
                for (int k = 0; k < 26; k++)
                    if (freq[k] > 0) {
                        mini = Math.Min(mini, freq[k]);
                        maxi = Math.Max(maxi, freq[k]);
                    }
                if (mini == maxi)
                    len = Math.Max(len, j - i + 1);
            }
        }
        return len;
    }
}
