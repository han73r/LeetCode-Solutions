public class Solution {
    public int MaxDistance(int[] colors) {
        int n = colors.Length;
        int max = 0;
        for (int i = 0; i < n; i++) {
            if (colors[i] != colors[0])
                max = Math.Max(max, i);
            if (colors[i] != colors[n - 1])
                max = Math.Max(max, n - 1 - i);   
        }
        return max;
    }
}
