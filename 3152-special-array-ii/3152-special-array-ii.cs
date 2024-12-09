public class Solution {
    public bool[] IsArraySpecial(int[] nums, int[][] queries) {
        int n = nums.Length;
        int[] prefix = new int[n];
        bool[] result = new bool[queries.Length];
        for (int i = 1; i < n; i++) {
            prefix[i] = prefix[i - 1];
            if ((nums[i - 1] % 2 == 0 && nums[i] % 2 == 0) ||
                (nums[i - 1] % 2 != 0 && nums[i] % 2 != 0)) {
                prefix[i]++;
            }
        }
        var l = queries.Length;
        for (int i = 0; i < l; i++) {
            int left = queries[i][0];
            int right = queries[i][1];
            int specialCount = prefix[right] - (left > 0 ? prefix[left] : 0);
            result[i] = (specialCount == 0);
        }
        return result;
    }
}