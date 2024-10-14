using System.Collections.Generic;
using System;

public class Solution {
    public long MaxKelements(int[] nums, int k) {
        var maxHeap = new PriorityQueue<long, long>(Comparer<long>.Create((x, y) => y.CompareTo(x)));
        foreach (var num in nums) {
            maxHeap.Enqueue(num, num);
        }
        long score = 0;
        for (int i = 0; i < k; i++) {
            long maxVal = maxHeap.Dequeue();
            score += maxVal;
            long newVal = (long)Math.Ceiling(maxVal / 3.0);
            maxHeap.Enqueue(newVal, newVal);
        }
        return score;
    }
}