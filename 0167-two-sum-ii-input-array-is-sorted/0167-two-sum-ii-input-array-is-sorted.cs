using System.Collections.Generic;

public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        int left = 0, right = 0;
        int[] result = new int[2];
        int n = numbers.Length;
        List<int> counter = new List<int>();
        for (int i = 0; i < n; i++) {
            if (counter.Contains(numbers[i])) {
                left = counter.IndexOf(numbers[i]);
                right = i;
                break;
            }
            counter.Add(target - numbers[i]);
        }
        result[0] = left + 1;
        result[1] = right + 1;
        return result;
    }
}