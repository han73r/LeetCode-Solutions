public class Solution {
    public int MinimizeXor(int num1, int num2) {
        int result = num1;
        int targetSetBitsCount = CountSetBits(num2);
        int setBitsCount = CountSetBits(result);
        int currentBit = 0;
        while (setBitsCount < targetSetBitsCount) {
            if (!IsSet(result, currentBit)) {
                SetBit(ref result, currentBit);
                setBitsCount++;
            }
            currentBit++;
        }
        while (setBitsCount > targetSetBitsCount) {
            if (IsSet(result, currentBit)) {
                UnsetBit(ref result, currentBit);
                setBitsCount--;
            }
            currentBit++;
        }
        return result;
    }
    private bool IsSet(int x, int bit) {
        return (x & (1 << bit)) != 0;
    }
    private int CountSetBits(int x) {
        int count = 0;
        while (x != 0) {
            count += (x & 1);
            x >>= 1;
        }
        return count;
    }
    private void SetBit(ref int x, int bit) {
        x |= (1 << bit);
    }
    private void UnsetBit(ref int x, int bit) {
        x &= ~(1 << bit);
    }
}