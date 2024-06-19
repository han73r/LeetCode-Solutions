using System.Linq;

public class Solution {
    public int MinDays(int[] bloomDay, int m, int k) {
        int result = -1;
        int n = bloomDay.Length;
        if (m * k > n) return result;

        int left = 0;
        int right = bloomDay.Max();

        while (left <= right) {
            int mid = left + (right - left) / 2;
            if (CanMakeBouquets(bloomDay, mid, k) >= m) {
                result = mid;
                right = mid - 1;
            } else {
                left = mid + 1;
            }
        }
        return result;
    }
    private int CanMakeBouquets(int[] bloomDay, int day, int k) {
        int bouquets = 0;
        int flowers = 0;
        foreach (int bloom in bloomDay) {
            if (bloom <= day) {
                flowers++;
                if (flowers == k) {
                    bouquets++;
                    flowers = 0;
                }
            } else {
                flowers = 0;
            }
        }
        return bouquets;
    }
}