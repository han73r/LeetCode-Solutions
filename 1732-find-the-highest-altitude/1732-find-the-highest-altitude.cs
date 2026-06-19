public class Solution {
    public int LargestAltitude(int[] gain) {
        int result = 0;
        int n = gain.Length;
        int currentGain = result;
        for (int i = 0; i < n; i++) {
            currentGain += gain[i];
            result = Math.Max(result, currentGain);
        }
        return result;
    }
}
