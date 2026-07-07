public class Solution {
    public long SumAndMultiply(int n) {
        int sum = 0;
        int multiplier = 1;
        int numberWithoutZeros = 0;
        while (n > 0) {
            int digit = n % 10;
            if (digit != 0) {
                sum += digit;
                numberWithoutZeros += digit * multiplier;
                multiplier *= 10;
            }
            n /= 10;
        }
        return (long)sum * numberWithoutZeros;
    }
}
