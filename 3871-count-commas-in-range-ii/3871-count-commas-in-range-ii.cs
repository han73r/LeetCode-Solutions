public class Solution {
    private const long InclusiveRngOffset = 1L;
    private const long CommaCntMult = 1000L;
    private const long MinNumWithCommas = 1000L;
    public long CountCommas(long num) {
        long commaCnt = 0L;
        long thresholdNum = MinNumWithCommas;
        while (thresholdNum <= num) {
            commaCnt += num - thresholdNum + InclusiveRngOffset;
            thresholdNum *= CommaCntMult;
        }
        return commaCnt;
    }
}
