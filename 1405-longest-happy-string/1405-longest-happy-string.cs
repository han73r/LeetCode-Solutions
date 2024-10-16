using System.Collections.Generic;
using System.Text;

public class Solution {
    public string LongestDiverseString(int a, int b, int c) {
        StringBuilder result = new StringBuilder();
        PriorityQueue<(int count, char ch), int> maxHeap = new PriorityQueue<(int count, char ch), int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));
        if (a > 0) maxHeap.Enqueue((a, 'a'), a);
        if (b > 0) maxHeap.Enqueue((b, 'b'), b);
        if (c > 0) maxHeap.Enqueue((c, 'c'), c);
        while (maxHeap.Count > 0) {
            var first = maxHeap.Dequeue();
            if (result.Length >= 2 && result[^1] == first.ch && result[^2] == first.ch) {
                if (maxHeap.Count == 0) break;
                var second = maxHeap.Dequeue();
                result.Append(second.ch);
                if (--second.count > 0) maxHeap.Enqueue(second, second.count);
                maxHeap.Enqueue(first, first.count);
            } else {
                result.Append(first.ch);
                if (--first.count > 0) maxHeap.Enqueue(first, first.count);
            }
        }
        return result.ToString();
    }
}