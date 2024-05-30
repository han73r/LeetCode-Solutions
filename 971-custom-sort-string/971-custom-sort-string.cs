using System.Collections.Generic;
using System.Text;

public class Solution {
    public string CustomSortString(string order, string s) {
        Dictionary<char, int> orderMap = new Dictionary<char, int>();
        for (int i = 0; i < order.Length; i++) {
            orderMap[order[i]] = i;
        }
        List<char> sortedChars = new List<char>(s.ToCharArray());
        sortedChars.Sort((a, b) => {
            if (orderMap.ContainsKey(a) && orderMap.ContainsKey(b)) {
                return orderMap[a] - orderMap[b];
            } else if (orderMap.ContainsKey(a)) {
                return -1;
            } else if (orderMap.ContainsKey(b)) {
                return 1;
            } else {
                return 0;
            }
        });
        StringBuilder result = new StringBuilder();
        foreach (char c in sortedChars) {
            result.Append(c);
        }
        return result.ToString();
    }
}