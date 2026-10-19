public class Solution {
    public IList<int> TargetIndices(int[] nums, int target) {
        int lessCount = 0;
        int targetCount = 0;

        foreach (int num in nums) {
            if (num < target) lessCount++;
            else if (num == target) targetCount++;
        }

        var result = new List<int>(targetCount);
        for (int i = 0; i < targetCount; i++) {
            result.Add(lessCount++);
        }

        return result;
    }
}
