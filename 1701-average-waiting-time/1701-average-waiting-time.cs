using System;

public class Solution {
    public double AverageWaitingTime(int[][] customers) {
        double totalWaitingTime = default;
        int currentTime = default;
        for (int i = 0; i < customers.Length; i++) {
            currentTime = Math.Max(currentTime, customers[i][0]);
            currentTime += customers[i][1];
            totalWaitingTime += currentTime - customers[i][0];
        }
        return totalWaitingTime / customers.Length;
    }
}