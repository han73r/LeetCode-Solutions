public class Solution {
  
    public int MinimumDistance(int[] nums) {
        int n = nums.Length;
        int size = int.MaxValue;
        if (n < 3) return -1;

        var map = new Dictionary<int, List<int>>();

        for (int i = 0; i < n; i++) {
            if (!map.ContainsKey(nums[i]))
                map[nums[i]] = new List<int>();
            map[nums[i]].Add(i);
        }

        foreach (var kv in map) {
            var list = kv.Value;
            if (list.Count >= 3) {
                size = Math.Min(size, MinimalDistanceInArray(list));
            }
        }
        
        return size == int.MaxValue ? -1 : size;
    }
  
    private static int MinimalDistanceInArray(List<int> array) {
        int min = int.MaxValue;
        for (int i = 0; i <= array.Count - 3; i++) {
            int dist = 2 * (array[i + 2] - array[i]);
            min = Math.Min(min, dist);
        }
        return min;
    }
}
