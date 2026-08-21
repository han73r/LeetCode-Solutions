public class Solution {
    public long GCD(long a, long b) {
        while (b != 0) {
            long temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    public long LCM(long a, long b) {
        return (a * b) / GCD(a, b);
    }

    public long FindKthSmallest(int[] coins, int k) {
        Array.Sort(coins);
        if (coins[0] == 1)
            return k;

        List<long> usefulCoins = new List<long>();
        for (int i = 0; i < coins.Length; ++i) {
            usefulCoins.Add(coins[i]);
        }
        for (int i = coins.Length - 1; i >= 0; --i) {
            for (int j = 0; j < i; ++j) {
                if (coins[i] % coins[j] == 0) {
                    usefulCoins.Remove(coins[i]);
                    break;
                }
            }
        }

        List<List<long>> combinations = GetCombinations(usefulCoins);

        long left = k;
        long right = (long)(usefulCoins[0]) * k;

        while (left <= right) {
            long mid = (left + right) / 2;
            long res = GetValidNumbersLessThan(combinations, mid);
            if (res >= k) {
                right = mid - 1;
            }
            else {
                left = mid + 1;
            }
        }

        return left;
    }

    public long GetValidNumbersLessThan(List<List<long>> combinations, long val) {
        long res = 0;

        for (int i = 0; i < combinations.Count; ++i) {
            long sign = (i % 2 == 0 ? 1 : -1);
            for (int j = 0; j < combinations[i].Count; ++j) {
                res += sign * (val / combinations[i][j]);
            }
        }

        return res;
    }

    public List<List<long>> GetCombinations(List<long> coins) {
        List<List<long>> combinations = new List<List<long>>();
        for (int i = 0; i < coins.Count; ++i) {
            combinations.Add(new List<long>());
        }

        int n = (1 << coins.Count);
        for (int i = 1; i < n; ++i) {
            int bitCount = 0;
            long lcm = 1;

            for (int idx = 0; idx < coins.Count; ++idx) {
                if (((1 << idx) & i) != 0) {
                    lcm = LCM(lcm, coins[idx]);
                    bitCount++;
                }
            }
            combinations[bitCount - 1].Add(lcm);
        }

        return combinations;
    }
}
