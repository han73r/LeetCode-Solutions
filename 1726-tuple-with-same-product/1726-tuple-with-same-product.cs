using System.Collections.Generic;

public class Solution {
    public int TupleSameProduct(int[] nums) {
        if (nums.Length < 4) return 0;
        int n = nums.Length;
        var product = new Dictionary<int, int>(n * n / 2);
        var sum = 0;
        for (int i = 0; i < n; i++) {
            for (int j = i + 1; j < n; j++) {
                int key = nums[i] * nums[j];
                if (product.ContainsKey(key))
                    product[key]++;
                else
                    product[key] = 1;
            }
        }
        foreach (var kvp in product) {
            int count = kvp.Value;
            if (count > 1)
                sum += count * (count - 1) * 4;
        }
        return sum;
    }
}