using System.Collections.Generic;
using System;

public class Solution {
    public int[] ArrayRankTransform(int[] arr) {
        if (arr.Length == 0) return arr;
        int[] sortedArr = (int[])arr.Clone();
        Array.Sort(sortedArr);
        Dictionary<int, int> rankMap = new Dictionary<int, int>();
        int rank = 1;
        for (int i = 0; i < sortedArr.Length; i++) {
            if (!rankMap.ContainsKey(sortedArr[i])) {
                rankMap[sortedArr[i]] = rank;
                rank++;
            }
        }
        int[] result = new int[arr.Length];
        for (int i = 0; i < arr.Length; i++) {
            result[i] = rankMap[arr[i]];
        }
        return result;
    }
}