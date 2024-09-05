public class Solution {
    public int[] MissingRolls(int[] rolls, int mean, int n) {
        int m = rolls.Length;
        int totalSum = mean * (n + m);
        int currentSum = 0;
        foreach (int roll in rolls) currentSum += roll;
        int missingSum = totalSum - currentSum;
        if (missingSum < n || missingSum > 6 * n) return new int[0];
        int[] result = new int[n];
        int baseValue = missingSum / n;
        int remainder = missingSum % n;
        for (int i = 0; i < n; i++) result[i] = baseValue + (i < remainder ? 1 : 0);
        return result;
    }
}