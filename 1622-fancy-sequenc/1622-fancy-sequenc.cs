public class Fancy {
    private const long MOD = 1000000007;
    private List<long> vals = new List<long>();
    private long a = 1;
    private long b = 0;
    
    public void Append(int val) {
        long x = (val - b + MOD) % MOD;
        long normalized = (x * ModPow(a, MOD - 2)) % MOD;
        vals.Add(normalized);
    }
    
    public void AddAll(int inc) {
        b = (b + inc) % MOD;
    }
    
    public void MultAll(int m) {
        a = (a * m) % MOD;
        b = (b * m) % MOD;
    }
    
    public int GetIndex(int idx) {
        if (idx >= vals.Count) return -1;
        return (int)((a * vals[idx] + b) % MOD);
    }
    
    private long ModPow(long x, long n) {
        if (n == 0) return 1;
        long half = ModPow(x, n / 2);
        long result = (half * half) % MOD;
        if (n % 2 == 1)
            result = (result * x) % MOD;
        return result;
    }
}
