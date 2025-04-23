public class Solution {
    public int CountLargestGroup(int n) {
        var dict = new Dictionary<int, int>();
        for (int i = 1; i <= n; i++) {
            int sum = 0;
            int num = i;

            while (num > 0) {
                sum += num % 10;
                num /= 10;
            }

            if (dict.ContainsKey(sum))
                dict[sum]++;
            else
                dict[sum] = 1;
        }
        int maxGroupSize = dict.Values.Max();
        return dict.Values.Count(v => v == maxGroupSize);
    }
}