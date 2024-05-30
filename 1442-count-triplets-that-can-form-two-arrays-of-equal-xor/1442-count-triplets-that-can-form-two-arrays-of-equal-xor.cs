public class Solution {
    public int CountTriplets(int[] arr) {
        int l = arr.Length;
        int count = 0;
        int[] prefixXOR = new int[l + 1];
        for (int i = 0; i < l; i++) {
            prefixXOR[i + 1] = prefixXOR[i] ^ arr[i];
        }
        for (int i = 0; i < l; i++) {
            for (int k = i + 1; k < l; k++) {
                if (prefixXOR[i] == prefixXOR[k + 1]) {
                    count += (k - i);
                }
            }
        }
        return count;
    }
}