public class Solution {
    public long MaxRunTime(int machines, int[] batteries) {
        long total = 0;
        for (int i = 0; i < batteries.Length; i++) total += batteries[i];
        long low = 0, high = total / machines;
        while (low < high) {
            long mid = (low + high + 1) >> 1;
            long required = mid * machines, supplied = 0;
            for (int i = 0; i < batteries.Length; i++) {
                long b = batteries[i];
                supplied += b < mid ? b : mid;
                if (supplied >= required) break;
            }
            if (supplied >= required) low = mid;
            else high = mid - 1;
        }
        return low;
    }
}
