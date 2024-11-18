public class Solution {
    public int[] Decrypt(int[] code, int k) {
        int n = code.Length;
        int[] result = new int[n];
        if (k == 0) return result;
        int start = k > 0 ? 1 : k;
        int end = k > 0 ? k : -1;
        int sum = 0;
        for (int i = start; i <= end; i++) {
            sum += code[(i + n) % n];
        }
        for (int i = 0; i < n; i++) {
            result[i] = sum;
            sum -= code[(start++ + n) % n];
            sum += code[(++end + n) % n];
        }
        return result;
    }
}