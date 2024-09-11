public class Solution {
    public int MinBitFlips(int start, int goal) {
        int xorResult = start ^ goal;
        return CountBits(xorResult);
    }
    private int CountBits(int number) {
        int count = 0;
        while (number > 0) {
            count += number & 1;
            number >>= 1;
        }
        return count;
    }
}