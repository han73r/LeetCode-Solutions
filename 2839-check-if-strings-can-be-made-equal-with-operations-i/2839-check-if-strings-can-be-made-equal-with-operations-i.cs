public class Solution {
    public bool CanBeEqual(string s1, string s2) {
        int i = 0, j = i + 2;
        int n = s1.Length;
        while (j < n) {
            if (s1[i] != s2[j] || s1[j] != s2[i]) {
                if (s1[i] != s2[i] || s1[j] != s2[j]) {
                    return false;
                }
            }
            i += 1;
            j += 1;
        }
        return true;
    }
}
