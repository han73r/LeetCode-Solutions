using System.Collections.Generic;

public class Solution {
    public int[] GetFinalState(int[] nums, int k, int multiplier) {
        var pq = new SortedSet<(int value, int index)>(Comparer<(int value, int index)>.Create((a, b) =>
            a.value == b.value ? a.index.CompareTo(b.index) : a.value.CompareTo(b.value)));
        for (int i = 0; i < nums.Length; i++) {
            pq.Add((nums[i], i));
        }
        while (k-- > 0) {
            var smallest = pq.Min;
            pq.Remove(smallest);
            pq.Add((smallest.value * multiplier, smallest.index));
        }
        foreach (var item in pq) {
            nums[item.index] = item.value;
        }
        return nums;
    }
}