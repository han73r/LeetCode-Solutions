using System.Collections.Generic;
using System.Linq;

public class Solution {
    public long MaximumHappinessSum(int[] happiness, int k) {
        long result = 0;
        happiness = happiness.OrderByDescending(x => x).ToArray();
        Queue<int> queue = new Queue<int>(happiness);
        for (int i = 0; i < k; i++) {
            if (queue.Peek() - i > 0) {
                result += queue.Dequeue() - i;
            }
        }
        return result;
    }
}