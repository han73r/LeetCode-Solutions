public class Solution {
    public int[] XorQueries(int[] arr, int[][] queries) {
        int n = arr.Length;
        int[] prefixXor = new int[n + 1];
        for (int i = 0; i < n; i++) {
            prefixXor[i + 1] = prefixXor[i] ^ arr[i];
        }
        int[] result = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++) {
            result[i] = prefixXor[queries[i][1] + 1] ^ prefixXor[queries[i][0]];
        }
        return result;
    }
}