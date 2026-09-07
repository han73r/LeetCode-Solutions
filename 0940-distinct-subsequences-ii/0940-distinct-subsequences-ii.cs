public class Solution {
    public int DistinctSubseqII(string s) {
        int kMod = 1_000_000_007;
        long[] dpSubseqCnts = new long[26];
        long subseqFinalCnt = 0;

        foreach (char chr in s) {
            int chrIdx = chr - 'a';
            long subseqNextCnt = (subseqFinalCnt + 1) % kMod;
            subseqFinalCnt = (subseqFinalCnt + subseqNextCnt - dpSubseqCnts[chrIdx] + kMod) % kMod;
            dpSubseqCnts[chrIdx] = subseqNextCnt;
        }
        
        return (int) subseqFinalCnt;
    }
}
