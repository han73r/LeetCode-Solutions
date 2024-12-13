using System.Collections.Generic;

public class Solution {
    public long FindScore(int[] nums) {
        int length = nums.Length;
        long totalScore = 0;
        var sortedValues = new List<(int value, int index)>(length);
        for (int i = 0; i < length; i++)
            sortedValues.Add((nums[i], i));
        sortedValues.Sort((a, b) => a.value == b.value ? a.index.CompareTo(b.index) : a.value.CompareTo(b.value));
        var usedIndices = new bool[length];
        foreach (var (value, index) in sortedValues) {
            if (usedIndices[index]) continue;
            totalScore += value;
            usedIndices[index] = true;
            if (index > 0) usedIndices[index - 1] = true;
            if (index < length - 1) usedIndices[index + 1] = true;
        }
        return totalScore;
    }
}