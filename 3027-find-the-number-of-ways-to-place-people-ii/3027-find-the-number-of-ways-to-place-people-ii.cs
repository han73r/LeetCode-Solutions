using System;
using System.Collections.Generic;

public class Solution {
    public int NumberOfPairs(int[][] arr) {
        int n = arr.Length;

        Array.Sort(arr, (a, b) => {
            if (a[0] == b[0]) return b[1].CompareTo(a[1]); // descending on y if x equal
            return a[0].CompareTo(b[0]); // ascending on x
        });

        int cnt = 0;
        for (int i = 0; i < n; i++) {
            int top = arr[i][1];
            int bot = int.MinValue;
            for (int j = i + 1; j < n; j++) {
                int y = arr[j][1];
                if (bot < y && y <= top) {
                    cnt++;
                    bot = y;
                    if (bot == top) break;
                }
            }
        }
        return cnt;
    }
}