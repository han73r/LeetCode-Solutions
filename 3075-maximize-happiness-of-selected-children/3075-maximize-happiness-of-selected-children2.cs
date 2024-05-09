using System;

public class Solution {
    public long MaximumHappinessSum(int[] happiness, int k) {
        long result = 0;
        Array.Sort(happiness);
        int length = happiness.Length - 1;
        int i = 0;
        while (i < k) {
            result += happiness[length - i] - i > 0 ? happiness[length - i] - i : 0;
            i++;
        }
        return result;
    }
}