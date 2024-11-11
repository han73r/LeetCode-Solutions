public class Solution {
    public bool PrimeSubOperation(int[] nums) {
        if (nums.Length == 1) return true;
        int l = nums.Length;
        int maxElement = GetMaxElement(nums);

        // Sieve of Atkin
        bool[] sieve = new bool[maxElement + 1];
        if (maxElement > 2) sieve[2] = true;
        if (maxElement > 3) sieve[3] = true;
        for (int x = 1; x * x <= maxElement; x++) {
            for (int y = 1; y * y <= maxElement; y++) {
                int n = (4 * x * x) + (y * y);
                if (n <= maxElement && (n % 12 == 1 || n % 12 == 5)) {
                    sieve[n] = !sieve[n];
                }

                n = (3 * x * x) + (y * y);
                if (n <= maxElement && n % 12 == 7) {
                    sieve[n] = !sieve[n];
                }

                n = (3 * x * x) - (y * y);
                if (x > y && n <= maxElement && n % 12 == 11) {
                    sieve[n] = !sieve[n];
                }
            }
        }
        for (int i = 5; i * i <= maxElement; i++) {
            if (sieve[i]) {
                for (int j = i * i; j <= maxElement; j += i * i) {
                    sieve[j] = false;
                }
            }
        }
        int currValue = 1;
        int k = 0;
        while (k < l) {
            int difference = nums[k] - currValue;
            if (difference < 0) {
                return false;
            }
            if (sieve[difference] || difference == 0) {
                k++;
                currValue++;
            } else {
                currValue++;
            }
        }
        return true;
    }
    private int GetMaxElement(int[] nums) {
        int max = -1;
        foreach (int num in nums) {
            if (num > max) {
                max = num;
            }
        }
        return max;
    }
}