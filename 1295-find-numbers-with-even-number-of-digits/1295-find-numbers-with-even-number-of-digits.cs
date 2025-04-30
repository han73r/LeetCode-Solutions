using System;

public class Solution {
    public int FindNumbers(int[] nums) {
        int counter = 0;
        foreach (int num in nums)
            if (Math.Abs(num).ToString().Length % 2 == 0)
                counter++;
        return counter;
    }
}