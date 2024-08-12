using System.Collections.Generic;

public class KthLargest {
    private readonly int k;
    private readonly SortedSet<(int Value, int Index)> minHeap;
    private int indexCounter;
    public KthLargest(int k, int[] nums) {
        this.k = k;
        minHeap = new SortedSet<(int Value, int Index)>();
        indexCounter = 0;
        foreach (int num in nums) {
            Add(num);
        }
    }
    public int Add(int val) {
        minHeap.Add((val, indexCounter++));
        if (minHeap.Count > k) {
            minHeap.Remove(minHeap.Min);
        }
        return minHeap.Min.Value;
    }
}
/**
 * Your KthLargest object will be instantiated and called as such:
 * KthLargest obj = new KthLargest(k, nums);
 * int param_1 = obj.Add(val);
 */