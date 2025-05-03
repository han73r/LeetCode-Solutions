using System;

public class Solution {
    public int MinDominoRotations(int[] tops, int[] bottoms) {
        int rotations = Check(tops[0], tops, bottoms);
        if (rotations != -1) return rotations;
        return Check(bottoms[0], tops, bottoms);
    }
    private int Check(int target, int[] tops, int[] bottoms) {
        int rotationTop = 0;
        int rotationBottom = 0;
        for (int i = 0; i < tops.Length; i++) {
            if (tops[i] != target && bottoms[i] != target)
                return -1;
            else if (tops[i] != target)
                rotationTop++;
            else if (bottoms[i] != target)
                rotationBottom++;
        }
        return Math.Min(rotationTop, rotationBottom);
    }
}