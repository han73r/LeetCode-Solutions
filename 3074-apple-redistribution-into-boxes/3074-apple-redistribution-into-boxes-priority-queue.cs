public class Solution {
    public int MinimumBoxes(int[] apple, int[] capacity) {
        int sum = apple.Sum();
        var counter = 0;
        var pq = new PriorityQueue<int, int>();
        foreach (var cap in capacity)
            pq.Enqueue(cap, -cap);
        while (sum > 0) {
            var max = pq.Dequeue();
            sum -= max;
            counter++;
        }
        return counter;
    }
}
