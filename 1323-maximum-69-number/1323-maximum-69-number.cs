using System;

public class Solution {
    public int Maximum69Number(int num) {
        int temp = num;
        int index = -1;
        int pos = 0;

        while (temp > 0) {
            if (temp % 10 == 6) index = pos;
            temp /= 10;
            pos++;
        }

        return (index == -1) ? num : num + 3 * (int)Math.Pow(10, index);
    }
}