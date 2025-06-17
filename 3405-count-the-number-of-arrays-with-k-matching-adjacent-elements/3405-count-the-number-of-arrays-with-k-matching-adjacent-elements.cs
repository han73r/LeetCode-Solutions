using System;
using System.Numerics;

public class Solution {
    const int MOD = 1_000_000_007;
    const int MAX = 100005;
    
    long[] factorial = new long[MAX];
    long[] invFactorial = new long[MAX];
    
    public Solution() {
        PrecomputeFactorials();
    }

    public int CountGoodArrays(int n, int m, int k) {
        long waysToChooseEquals = nCr(n - 1, k);
        long groupValueWays = m * ModPow(m - 1, n - 1 - k) % MOD;
        return (int)(waysToChooseEquals * groupValueWays % MOD);
    }

    void PrecomputeFactorials() {
        factorial[0] = 1;
        for (int i = 1; i < MAX; i++)
            factorial[i] = factorial[i - 1] * i % MOD;
        
        invFactorial[MAX - 1] = ModInverse(factorial[MAX - 1]);
        for (int i = MAX - 2; i >= 0; i--)
            invFactorial[i] = invFactorial[i + 1] * (i + 1) % MOD;
    }

    long nCr(int n, int r) {
        if (r < 0 || r > n) return 0;
        return factorial[n] * invFactorial[r] % MOD * invFactorial[n - r] % MOD;
    }

    long ModPow(long a, long b) {
        long res = 1;
        a %= MOD;
        while (b > 0) {
            if ((b & 1) == 1)
                res = res * a % MOD;
            a = a * a % MOD;
            b >>= 1;
        }
        return res;
    }

    long ModInverse(long a) => ModPow(a, MOD - 2);
}