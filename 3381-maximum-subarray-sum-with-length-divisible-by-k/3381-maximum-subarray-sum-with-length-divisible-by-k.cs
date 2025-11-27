public class Solution {
    public long MaxSubarraySum(int[] nums, int k) {
        Span<long> minPrefix = stackalloc long[k];
        for (int i = 0; i < k; i++) minPrefix[i] = long.MaxValue;
        minPrefix[0] = 0;
        long prefix = 0, answer = long.MinValue;
        for (int i = 0; i < nums.Length; i++) {
            prefix += nums[i];
            int mod = (i + 1) % k;
            answer = minPrefix[mod] != long.MaxValue ? Math.Max(answer, prefix - minPrefix[mod]) : answer;
            minPrefix[mod] = prefix < minPrefix[mod] ? prefix : minPrefix[mod];
        }
        return answer;
    }
}
