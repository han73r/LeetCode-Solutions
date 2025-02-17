using System.Collections.Generic;
using System.Linq;

public class Solution {
    private int[] fact = new int[] { 1, 1, 2, 6, 24, 120, 720, 5040 };
    private HashSet<string> hs = new();
    public int NumTilePossibilities(string tiles) {
        tiles = new string(tiles.OrderBy(c => c).ToArray());
        FindAllPossible(0, tiles, "");
        int ans = 0;
        foreach (var str in hs)
            ans += UniquePermutation(str);
        return ans;
    }
    private int UniquePermutation(string str) {
        if (str == "") return 0;
        int n = str.Length;
        int[] freq = new int[26];
        for (int i = 0; i < str.Length; i++)
            freq[str[i] - 'A']++;
        int answer = fact[n];
        foreach (var cnt in freq)
            answer /= fact[cnt];
        return answer;
    }
    private void FindAllPossible(int idx, string str, string current) {
        if (idx == str.Length) {
            hs.Add(current);
            return;
        }
        FindAllPossible(idx + 1, str, current + str[idx]);
        FindAllPossible(idx + 1, str, current);
    }
}