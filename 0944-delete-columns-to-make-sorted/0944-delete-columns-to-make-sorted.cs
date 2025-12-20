public class Solution {
    public int MinDeletionSize(string[] strs) {
        int n = strs.Length;
        int stringSize = strs[0].Length;
        int counter = 0;
        for (int j = 0; j < stringSize; j++) {
            char previous = strs[0][j];
            for (int i = 1; i < n; i++) {
                if (strs[i][j] < previous) {
                    counter++;
                    break;
                }
                previous = strs[i][j];
            }
        }
        return counter;
    }
} 
