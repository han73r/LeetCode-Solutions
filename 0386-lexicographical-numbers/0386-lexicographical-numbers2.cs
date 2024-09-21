using System.Collections.Generic;

public class Solution {
    public IList<int> LexicalOrder(int n) {
        List<int> result = new List<int>();
        int current = 1;
        for (int i = 0; i < n; i++) {
            result.Add(current);
            if (current * 10 <= n) {
                current *= 10;
            } else {
                if (current >= n) current /= 10;
                current++;
                while (current % 10 == 0) {
                    current /= 10;
                }
            }
        }
        return result;
    }
}
