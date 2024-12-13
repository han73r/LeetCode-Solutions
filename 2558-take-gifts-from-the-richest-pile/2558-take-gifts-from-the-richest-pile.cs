using System;

public class Solution {
    public long PickGifts(int[] gifts, int k) {
        PriorityQueue<long, long> maxHeap = FillTheHeap(gifts);
        maxHeap = PickOperation(maxHeap, k);
        return CountSum(maxHeap);
    }
    private PriorityQueue<long, long> FillTheHeap(int[] input) {
        var heap = new PriorityQueue<long, long>();
        foreach (var i in input) {
            heap.Enqueue(i, -i);
        }
        return heap;
    }
    private PriorityQueue<long, long> PickOperation(PriorityQueue<long, long> heap, int k) {
        while (k > 0) {
            long maxValue = heap.Dequeue();
            long newValue = (long)Math.Sqrt(maxValue);
            heap.Enqueue(newValue, -newValue);
            k--;
        }
        return heap;
    }
    private long CountSum(PriorityQueue<long, long> heap) {
        long totalSum = 0;
        while (heap.Count > 0) {
            totalSum += heap.Dequeue();
        }
        return totalSum;
    }
}