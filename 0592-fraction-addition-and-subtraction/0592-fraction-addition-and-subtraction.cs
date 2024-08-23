using System;

public class Solution {
    public string FractionAddition(string expression) {
        int numerator = 0, denominator = 1;
        int i = 0, n = expression.Length;
        while (i < n) {
            int sign = 1;
            if (expression[i] == '-' || expression[i] == '+') {
                sign = expression[i] == '-' ? -1 : 1;
                i++;
            }
            int num = 0;
            while (i < n && char.IsDigit(expression[i])) {
                num = num * 10 + (expression[i] - '0');
                i++;
            }
            num *= sign;
            i++;
            int den = 0;
            while (i < n && char.IsDigit(expression[i])) {
                den = den * 10 + (expression[i] - '0');
                i++;
            }
            numerator = numerator * den + num * denominator;
            denominator *= den;
            int gcd = GCD(Math.Abs(numerator), denominator);
            numerator /= gcd;
            denominator /= gcd;
        }
        return numerator + "/" + denominator;
    }
    private int GCD(int a, int b) {
        while (b != 0) {
            int t = b;
            b = a % b;
            a = t;
        }
        return a;
    }
}