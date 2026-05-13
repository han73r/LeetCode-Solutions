public class Solution {
    public int MinMoves(int[] nums, int limit) {
        int pairCount = nums.Length / 2;
        var sumFrequency = new Dictionary<int, int>();
        var low = new int[pairCount];
        var high = new int[pairCount];

        for (int i = 0; i < pairCount; i++) {
            int left = nums[i];
            int right = nums[nums.Length - 1 - i];
            int min = Math.Min(left, right);
            int max = Math.Max(left, right);
            low[i] = min;
            high[i] = max;
            int sum = min + max;
            sumFrequency[sum] = sumFrequency.GetValueOrDefault(sum) + 1;
        }

        Array.Sort(low);
        Array.Sort(high);
        
        int GetLowerBound(int[] arr, int value) {
            int l = 0, r = arr.Length;
            while (l < r) {
                int mid = l + (r - l) / 2;
                if (arr[mid] >= value) r = mid;
                else l = mid + 1;
            }
            return l;
        }

        int minOperations = int.MaxValue;
        for (int targetSum = 2; targetSum <= 2 * limit; targetSum++) {
            int goodPairs = sumFrequency.GetValueOrDefault(targetSum);
            int needIncrease = pairCount - GetLowerBound(low, targetSum);
            int needDecrease = GetLowerBound(high, targetSum - limit);
            int ops = pairCount + needIncrease + needDecrease - goodPairs;
            if (ops < minOperations) minOperations = ops;
        }
        return minOperations;
    }
}
