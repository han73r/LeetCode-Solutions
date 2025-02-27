using System.Collections.Generic;

public class Solution {
    public int LenLongestFibSubseq(int[] arr) {
        Dictionary<int, List<int>> numIdx = new();
        for (int i = 1; i < arr.Length; i++) {
            int n = arr[i];
            if (!numIdx.TryGetValue(n, out var indices)) {
                indices = numIdx[n] = new();
            }
            indices.Add(n);
        }
        int best = 2;
        for (int i = 0; i < arr.Length - 2; i++) {
            int ni = arr[i];
            for (int j = i + 1; j < arr.Length - 1; j++) {
                int count = 2, prevPrev = ni, prevNum = arr[j], prevIdx = j;
                for (; ; )  {
                    int n = prevPrev + prevNum;
                    if (!numIdx.TryGetValue(n, out var indices)) break;
                    int k = ~indices.BinarySearch(prevIdx);
                    if (k == indices.Count) break;
                    count++;
                    prevPrev = prevNum;
                    prevNum = n;
                    prevIdx = k;
                }
                if (count > best)
                    best = count;
            }
        }
        return best > 2 ? best : 0;
    }
}