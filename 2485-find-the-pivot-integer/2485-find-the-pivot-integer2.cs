public class Solution {
    public int PivotInteger(int n) {
        int left, right;
        for (int i = n; i > 0; i--) {
            left = SumCount(1, i);
            right = SumCount(i, n);
            if (left == right) {
                return i;
            } else if (right > left) {
                break;
            }
        }
        return -1;
    }

    private int SumCount(int first, int last) {
        return ((last - first + 1) * (last + first)) / 2;
    }
}