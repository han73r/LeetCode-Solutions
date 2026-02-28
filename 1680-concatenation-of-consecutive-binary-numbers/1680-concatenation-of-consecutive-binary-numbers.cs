public class Solution {
    public int ConcatenatedBinary(int n) {
        int mod = 1_000_000_007;
        int curBits = 0;
        long output = 0;
        for(int i = 1; i <= n; i++){
            if((i & (i-1)) == 0){
                curBits++;
            }
            output = ((output << curBits) | i) % mod;
        }
        return (int) output;
    }
}
