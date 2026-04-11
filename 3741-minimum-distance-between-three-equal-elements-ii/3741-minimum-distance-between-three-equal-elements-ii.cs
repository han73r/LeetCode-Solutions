public class Solution {
    public int MinimumDistance(int[] nums) {
        int res = int.MaxValue;
        var idxs = new (int, int, int, int, int)[nums.Length+1];
        
        for(int i=0; i<nums.Length; ++i) {
            var n = nums[i];
            var (cnt, fst, sec, thi, bst) = idxs[n];
            if (cnt == 0)
                idxs[n] = (1, i, 0, 0, 0);
            else if (cnt == 1)
                idxs[n] = (2, fst, i, 0, 0);
            else if (cnt == 2) {
                var dst = i-fst;
                if (dst < res)
                    res = dst;
                idxs[n] = (3, fst, sec, i, dst);
            } else {
                var dst = i-sec;
                if (dst < res)
                    res = dst;
                idxs[n] = (cnt+1, sec, thi, i, Math.Min(dst, bst));
            }
        }
        return res != int.MaxValue
            ? 2*res
            : -1;
    }
}
