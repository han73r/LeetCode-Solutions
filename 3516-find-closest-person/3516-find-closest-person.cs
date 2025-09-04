using System;

public class Solution {
    public int FindClosest(int x, int y, int z) {
        int zx = Math.Abs(z - x);
        int zy = Math.Abs(z - y);
        if (zx < zy)
            return 1;
        else if (zx > zy)
            return 2;
        else
            return 0;
    }
}