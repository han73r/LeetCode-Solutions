using System.Collections.Generic;
using System.Text;
using System;

public class Solution {
    public string FractionToDecimal(int numerator, int denominator) {
        if (numerator == 0) return "0";
        var sb = new StringBuilder();
        if ((numerator < 0) ^ (denominator < 0)) sb.Append("-");

        long num = Math.Abs((long)numerator);
        long den = Math.Abs((long)denominator);

        sb.Append(num / den);
        long rem = num % den;
        if (rem == 0) return sb.ToString();

        sb.Append(".");
        var seen = new Dictionary<long, int>();

        while (rem != 0) {
            if (seen.ContainsKey(rem)) {
                sb.Insert(seen[rem], "(");
                sb.Append(")");
                break;
            }
            seen[rem] = sb.Length;
            rem *= 10;
            sb.Append(rem / den);
            rem %= den;
        }
        return sb.ToString();
    }
}