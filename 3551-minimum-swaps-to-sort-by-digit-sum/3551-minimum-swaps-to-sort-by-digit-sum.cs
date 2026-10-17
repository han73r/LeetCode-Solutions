public class Solution {
    public int MinSwaps(int[] nums) {
        int n = nums.Length;
        int ans = 0;
        var items = new (int Val, int OrigIdx)[n];

        for (int i = 0; i < n; i++)
            items[i] = (nums[i], i);

        Array.Sort(items, (a, b) => {
            int sumA = GetDigitSum(a.Val);
            int sumB = GetDigitSum(b.Val);
            if (sumA != sumB)
                return sumA.CompareTo(sumB);
            return a.Val.CompareTo(b.Val);
        });
        
        bool[] visited = new bool[n];
        
        for (int i = 0; i < n; i++) {
            if (visited[i] || items[i].OrigIdx == i)
                continue;

            int cycleSize = 0;
            int j = i;
            
            while (!visited[j]) {
                visited[j] = true;
                j = items[j].OrigIdx;
                cycleSize++;
            }
            
            if (cycleSize > 0)
                ans += (cycleSize - 1);
        }
        
        return ans;
    }
    
    private int GetDigitSum(int num) {
        int sum = 0;

        while (num > 0) {
            sum += num % 10;
            num /= 10;
        }
        
        return sum;
    }
}
