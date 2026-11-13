public class Solution {
    public long CountNonDecreasingSubarrays(int[] nums, int k) {
        int n = nums.Length;
        long ans = 0;
        long operations = 0;
        var q = new PriorityQueue<(int val, int idx), int>();
        var cnt = new List<int>[n];

        for (int i = 0; i < n; i++) {
            cnt[i] = new List<int>();
        }

        var pos = new int[n];
        Array.Fill(pos, n);
        var st = new Stack<int>();

        for (int left = 0, right = 0; right < n; right++) {
            while (st.Count > 0 && nums[right] >= nums[st.Peek()]) {
                pos[st.Peek()] = right;
                st.Pop();
            }
            
            if (st.Count > 0) {
                cnt[st.Peek()].Add(right);
            }

            st.Push(right);
            q.Enqueue((nums[right], right), -nums[right]);
            operations += Math.Max(0, q.Peek().val - nums[right]);

            while (operations > k) {
                foreach (int i in cnt[left]) {
                    operations -= (long)(nums[left] - nums[i]) *
                                  (Math.Min(pos[i], right + 1) - i);
                }
                left++;
            }

            while (q.Count > 0 && q.Peek().idx < left) {
                q.Dequeue();
            }

            ans += right - left + 1;
        }

        return ans;
    }
}
