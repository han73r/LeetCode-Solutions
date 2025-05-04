using System;

public class Solution {
    public int NumEquivDominoPairs(int[][] dominoes) {
        int[] array = new int[45];
        foreach (var domino in dominoes)
            array[GetIndex(domino)]++;
        int result = 0;
        foreach (int count in array)
            if (count > 1)
                result += count * (count - 1) / 2;
        return result;
    }
    private int GetIndex(int[] nums) {
        int a = Math.Min(nums[0], nums[1]);
        int b = Math.Max(nums[0], nums[1]);
        return (a - 1) * 9 - (a - 2) * (a - 1) / 2 + (b - a);
    }
}