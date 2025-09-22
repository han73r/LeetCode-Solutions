using System.Collections.Generic;

public class Solution {
    public int MaxFrequencyElements(int[] nums) {
        var frequencyDic = new Dictionary<int, int>();
        var result = 0;
        foreach (var num in nums) {
            if (!frequencyDic.ContainsKey(num))
                frequencyDic.Add(num, 1);
            else
                frequencyDic[num]++;
        }
        var maxFrequency = frequencyDic.Values.Max();
        foreach (var kvp in frequencyDic) {
            if (kvp.Value == maxFrequency)
                result += maxFrequency;
        }
        return result;
    }
}