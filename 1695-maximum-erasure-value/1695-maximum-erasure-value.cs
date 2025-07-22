using System;

public class Solution {
    public int MaximumUniqueSubarray(int[] nums) {
        Span<bool> seen = stackalloc bool[100001];
        int maxScore = 0, score = 0, l = 0, r = 0;
        for (; r < nums.Length; r++) {
            int nr = nums[r];
            if (seen[nr]) {
                if (score > maxScore) maxScore = score;
                for (int nl = nums[l]; nr != nl; nl = nums[++l]) {
                    seen[nl] = false;
                    score -= nl;
                }
                l++;
            } else {
                seen[nr] = true;
                score += nr;
            }
        }
        return Math.Max(score, maxScore);
    }
}