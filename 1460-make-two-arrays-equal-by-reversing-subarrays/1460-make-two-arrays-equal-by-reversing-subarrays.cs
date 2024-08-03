using System.Collections.Generic;

public class Solution {
    public bool CanBeEqual(int[] target, int[] arr) {
        Dictionary<int, int> countTarget = new Dictionary<int, int>();
        foreach (int t in target) {
            if (countTarget.ContainsKey(t)) {
                countTarget[t]++;
            } else {
                countTarget.Add(t, 1);
            }
        }
        foreach (int a in arr) {
            if (countTarget.ContainsKey(a)) {
                countTarget[a]--;
            } else {
                return false;
            }
            if (countTarget[a] == 0) {
                countTarget.Remove(a);
            }
        }
        return true;
    }
}