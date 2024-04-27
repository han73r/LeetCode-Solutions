using System.Collections.Generic;
using System;

public class Solution {
    public int FindRotateSteps(string ring, string key) {
        Dictionary<string, int> memo = new Dictionary<string, int>();
        return DFS(ring, key, 0, memo);
    }

    private int DFS(string ring, string key, int index, Dictionary<string, int> memo) {
        if (index == key.Length) return 0;
        string keyRing = ring + index.ToString();
        if (memo.TryGetValue(keyRing, out int steps)) return steps;

        char target = key[index];
        int minSteps = int.MaxValue;

        for (int i = 0; i < ring.Length; i++) {
            if (ring[i] == target) {
                int stepsToRotate = Math.Min(i, ring.Length - i);
                string rotatedRing = RotateRing(ring, i);
                steps = stepsToRotate + 1 + DFS(rotatedRing, key, index + 1, memo);
                minSteps = Math.Min(minSteps, steps);
            }
        }
        memo[keyRing] = minSteps;
        return minSteps;
    }

    private string RotateRing(string ring, int steps) {
        return ring.Substring(steps) + ring.Substring(0, steps);
    }
}