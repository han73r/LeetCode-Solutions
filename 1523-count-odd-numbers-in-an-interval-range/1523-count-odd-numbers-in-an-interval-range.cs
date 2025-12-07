public class Solution {
    public int CountOdds(int low, int high) {
        int count = (high - low) / 2;
        if (low % 2 != 0 || high % 2 != 0)
            count++;
        return count;
    }
}
