using System.Linq;

public class Solution {
    public int MinimumSize(int[] nums, int maxOps) {
        int low = 1, high = nums.Max();
        while (low < high) {
            int mid = (low + high) / 2;
            int ops = nums.Sum(n => (n - 1) / mid);
            if (ops <= maxOps) high = mid;
            else low = mid + 1;
        }
        return high;
    }
}