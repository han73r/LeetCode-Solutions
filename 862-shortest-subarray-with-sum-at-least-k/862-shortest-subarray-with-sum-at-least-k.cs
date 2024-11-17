using System.Collections.Generic;
using System;

public class Solution {
    public int ShortestSubarray(int[] nums, int k) {
        int n = nums.Length;
        long[] prefixSum = new long[n + 1];
        for (int i = 0; i < n; i++) {
            prefixSum[i + 1] = prefixSum[i] + nums[i];
        }
        Deque<int> deque = new Deque<int>();
        int minLength = n + 1;
        for (int i = 0; i <= n; i++) {
            while (deque.Count > 0 && prefixSum[i] - prefixSum[deque.PeekFirst()] >= k) {
                minLength = Math.Min(minLength, i - deque.RemoveFirst());
            }
            while (deque.Count > 0 && prefixSum[i] <= prefixSum[deque.PeekLast()]) {
                deque.RemoveLast();
            }
            deque.AddLast(i);
        }

        return minLength <= n ? minLength : -1;
    }
    private class Deque<T> {
        private LinkedList<T> list = new LinkedList<T>();
        public int Count => list.Count;
        public void AddLast(T value) => list.AddLast(value);
        public T RemoveFirst() {
            var value = list.First.Value;
            list.RemoveFirst();
            return value;
        }
        public T RemoveLast() {
            var value = list.Last.Value;
            list.RemoveLast();
            return value;
        }
        public T PeekFirst() => list.First.Value;
        public T PeekLast() => list.Last.Value;
    }
}