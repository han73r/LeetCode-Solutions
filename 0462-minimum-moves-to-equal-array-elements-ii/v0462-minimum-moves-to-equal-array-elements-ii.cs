public class Solution {
    public int MinMoves2(int[] nums) {
        long min = int.MaxValue;
        
        for (int i = 0; i < nums.Length; i++) {
            int candidate = nums[i];
            long moves = 0;
            for (int j = 0; j < nums.Length; j++) {
                if (i == j) continue;
                moves += Math.Abs(nums[i] - nums[j]);
            }

            if (moves < min) 
                min = moves;
        }

        return (int)min;
    }
}
