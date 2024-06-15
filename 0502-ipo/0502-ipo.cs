using System.Collections.Generic;

public class Solution {
    public int FindMaximizedCapital(int k, int w, int[] profits, int[] capital) {
        int n = profits.Length;
        PriorityQueue<(int capital, int profit), int> minHeap = new PriorityQueue<(int, int), int>();
        PriorityQueue<int, int> maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
        for (int i = 0; i < n; i++) {
            minHeap.Enqueue((capital[i], profits[i]), capital[i]);
        }
        int currentCapital = w;
        for (int i = 0; i < k; i++) {
            while (minHeap.Count > 0 && minHeap.Peek().capital <= currentCapital) {
                var project = minHeap.Dequeue();
                maxHeap.Enqueue(project.profit, project.profit);
            }
            if (maxHeap.Count == 0) {
                break;
            }
            currentCapital += maxHeap.Dequeue();
        }
        return currentCapital;
    }
}