using System.Collections.Generic;

public class Solution {
    public int NumRabbits(int[] answers) {
        var countMap = new Dictionary<int, int>();
        int result = 0;
        foreach (int answer in answers) {
            if (!countMap.ContainsKey(answer)) {
                countMap[answer] = 0;
            }
            if (countMap[answer] == 0) {
                result += answer + 1;
                countMap[answer] = answer;
            } else {
                countMap[answer]--;
            }
        }
        return result;
    }
}