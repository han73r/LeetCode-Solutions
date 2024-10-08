public class Solution {
    public int MinSwaps(string s) {
        int imbalance = 0;
        int unmatchedClosing = 0;
        foreach (char c in s) {
            if (c == '[') {
                imbalance--;
            } else {
                imbalance++;
                if (imbalance > 0) {
                    unmatchedClosing++;
                    imbalance--;
                }
            }
        }
        return (unmatchedClosing + 1) / 2;
    }
}