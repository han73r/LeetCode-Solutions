public class Solution {
    public int TrailingZeroes(int n) {
        return n / 5 + n / 25 + n / 125 + n / 625 + n / 3125;
    }
}