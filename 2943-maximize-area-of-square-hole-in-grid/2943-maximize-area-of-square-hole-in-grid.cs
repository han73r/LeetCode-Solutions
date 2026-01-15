public class Solution {
    private int maxLen(int[] Bars) {
        int count = 2, length = 2;
        for(int i = 1; i < Bars.Length; i++) {
            if(Bars[i] - Bars[i-1] == 1) count++;
            else count = 2;
            length = Math.Max(length, count);
        }
        return length;
    }
    public int MaximizeSquareHoleArea(int n, int m, int[] hBars, int[] vBars) {
        Array.Sort(hBars);
        Array.Sort(vBars);
        int side = Math.Min(maxLen(hBars), maxLen(vBars));
        return side * side; 
    }
}
