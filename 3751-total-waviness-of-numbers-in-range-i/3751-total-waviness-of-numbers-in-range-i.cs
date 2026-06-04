public class Solution {
    private static int[] pref;
    private static readonly object _lock = new object();

    private static void InitPrefix() {
        if (pref != null) return;
        lock (_lock) {
            if (pref != null) return;
            pref = new int[100005];
            for (int i = 100; i < 100005; i++) {
                string snum = i.ToString();
                int waviness = 0;
                for (int j = 1; j < snum.Length - 1; j++) {
                    if ((snum[j] < snum[j - 1] && snum[j] < snum[j + 1]) || 
                        (snum[j] > snum[j - 1] && snum[j] > snum[j + 1])) {
                        waviness++;
                    }
                }
                pref[i] = pref[i - 1] + waviness;
            }
        }
    }

    public int TotalWaviness(int num1, int num2) {
        InitPrefix();
        return pref[num2] - pref[num1 - 1];
    }
}
