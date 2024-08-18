using System.Collections.Generic;
using System;

public class Solution {
    private static List<int> uglyNumbers;
    private const int uglyNumbersCount = 1690;
    static Solution() {
        uglyNumbers = new List<int> { 1 };
        FillUglyNumbers();
    }
    public int NthUglyNumber(int n) {
        return uglyNumbers[n - 1];
    }
    private static void FillUglyNumbers() {
        int i2 = 0, i3 = 0, i5 = 0;
        int next2 = 2, next3 = 3, next5 = 5;
        for (int i = 1; i < uglyNumbersCount; i++) {
            int nextUgly = Math.Min(next2, Math.Min(next3, next5));
            uglyNumbers.Add(nextUgly);
            if (nextUgly == next2) {
                i2++;
                next2 = uglyNumbers[i2] * 2;
            }
            if (nextUgly == next3) {
                i3++;
                next3 = uglyNumbers[i3] * 3;
            }
            if (nextUgly == next5) {
                i5++;
                next5 = uglyNumbers[i5] * 5;
            }
        }
    }
}