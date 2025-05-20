public class Solution {
    public bool IsZeroArray(int[] nums, int[][] queries) {
        int len = nums.Length;
        var dip = new int[len + 1];
        foreach (var item in queries) {
            int temp = item[0], end = item[1];
            dip[temp]++;
            dip[end + 1]--;
        }

        for (int i = 0, s = 0; i < len; i++) {
            s += dip[i];
            if (nums[i] > s)
                return false;
        }
        return true;
    }
}