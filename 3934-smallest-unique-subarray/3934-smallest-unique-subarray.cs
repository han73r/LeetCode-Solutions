public class Solution {
    private const long Mod = 1_000_000_007L;

    private long BinPow(long a, long b) {
        long ret = 1;
        a %= Mod;
        while (b > 0) {
            if ((b & 1) == 1) {
                ret = (ret * a) % Mod;
            }
            a = (a * a) % Mod;
            b /= 2;
        }
        return ret;
    }

    private long ComputeHash(int[] v, int i, int j, long baseVal) {
        long p = 1;
        long ret = 0;
        for (int x = i; x <= j; x++) {
            ret = (ret + (v[x] * p) % Mod) % Mod;
            p = (p * baseVal) % Mod;
        }
        return ret;
    }

    private bool Check(int[] v, int m) {
        var mp = new Dictionary<long, int>();
        long baseVal = 13;
        long x = ComputeHash(v, 0, m - 1, baseVal);
        long p = BinPow(baseVal, m - 1);
        long inv = BinPow(baseVal, Mod - 2);

        mp[x] = 1;

        for (int i = 0, j = m; j < v.Length; i++, j++) {
            x = ((x - v[i]) % Mod + Mod) % Mod;
            x = (x * inv) % Mod;
            x = (x + (v[j] * p) % Mod) % Mod;
            if (mp.ContainsKey(x)) {
                mp[x]++;
            } else {
                mp[x] = 1;
            }
        }

        foreach (int count in mp.Values) {
            if (count == 1) return true;
        }
        return false;
    }

    public int SmallestUniqueSubarray(int[] nums) {
        int low = 1, high = nums.Length, ans = nums.Length;
        while (low <= high) {
            int mid = low + (high - low) / 2;
            if (Check(nums, mid)) {
                ans = mid;
                high = mid - 1;
            } else {
                low = mid + 1;
            }
        }
        return ans;
    }
}
