public class Solution {
    public int MaximumSwap(int num) {
        char[] digits = num.ToString().ToCharArray();
        int[] last = new int[10];
        for (int i = 0; i < digits.Length; i++) {
            last[digits[i] - '0'] = i;
        }
        for (int i = 0; i < digits.Length; i++) {
            for (int d = 9; d > digits[i] - '0'; d--) {
                if (last[d] > i) {
                    char temp = digits[i];
                    digits[i] = digits[last[d]];
                    digits[last[d]] = temp;
                    return int.Parse(new string(digits));
                }
            }
        }
        return num;
    }
}