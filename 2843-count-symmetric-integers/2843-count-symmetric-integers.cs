public class Solution {
    public int CountSymmetricIntegers(int low, int high) {
        int result = 0;
        for (int i = low; i <= high; i++) {
            string s = i.ToString();
            if (s.Length % 2 != 0) continue;
            if (IsSymmetric(s)) result++;
        }
        return result;
    }
    private bool IsSymmetric(string s) {
        int half = s.Length / 2;
        int sum1 = 0, sum2 = 0;
        for (int i = 0; i < half; i++) {
            sum1 += s[i] - '0';
            sum2 += s[i + half] - '0';
        }
        return sum1 == sum2;
    }
}