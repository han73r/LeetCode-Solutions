using System.Collections.Generic;

public class Solution {
    public int FindLucky(int[] arr) {
        var dict = new Dictionary<int, int>();
        foreach (var item in arr)
            dict[item] = dict.GetValueOrDefault(item, 0) + 1;
        var sorte = dict.OrderByDescending(x => x.Value);
        foreach (var item in sorte)
            if (item.Value == item.Key)
                return item.Key;

        return -1;
    }
}