using System;

public class Solution {
    public int MaxDistance(string s, int k) {
        int latitude = 0, longitude = 0, ans = 0;
        int n = s.Length;
        for (int i = 0; i < n; i++) {
            switch (s[i]) {
                case 'N':
                    latitude++;
                    break;
                case 'S':
                    latitude--;
                    break;
                case 'E':
                    longitude++;
                    break;
                case 'W':
                    longitude--;
                    break;
            }
            ans = Math.Max(
                ans,
                Math.Min(Math.Abs(latitude) + Math.Abs(longitude) + k * 2,
                    i + 1));
        }
        return ans;
    }
}