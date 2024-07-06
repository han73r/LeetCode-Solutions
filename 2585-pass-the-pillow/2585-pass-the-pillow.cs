public class Solution {
    public int PassThePillow(int n, int time) {
        int cycleLength = 2 * (n - 1);
        int positionInCycle = time % cycleLength;
        if (positionInCycle < n) {
            return 1 + positionInCycle;
        } else {
            return n - (positionInCycle - (n - 1));
        }
    }
}