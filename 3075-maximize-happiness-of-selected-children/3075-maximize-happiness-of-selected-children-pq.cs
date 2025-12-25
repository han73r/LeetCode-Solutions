public class Solution {
    public long MaximumHappinessSum(int[] happiness, int k) {
        var pq = new PriorityQueue<int, int>();
        long result = 0;
        int picked = 0;
        foreach (int h in happiness)
            pq.Enqueue(h, -h); // max-heap
        while (k-- > 0 && pq.Count > 0) {
            int h = pq.Dequeue();
            int effective = h - picked;
            if (effective <= 0) break;
            result += effective;
            picked++;
        }
        return result;
    }
}
