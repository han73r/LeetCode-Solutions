public class Solution {
    public int GcdOfOddEvenSums(int n) {
        int sumOdd = 0;
        int sumEven = 0;
        int odd = 1;
        int even = 2;
        int counter = 0;

        while (counter < n) {
            sumOdd += odd;
            sumEven += even;
            odd += 2;
            even += 2;
            counter++;
        }

        return GCD(sumOdd, sumEven);
    }

    private int GCD(int a, int b) {
        while (b != 0) {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return Math.Abs(a);
    }
}
