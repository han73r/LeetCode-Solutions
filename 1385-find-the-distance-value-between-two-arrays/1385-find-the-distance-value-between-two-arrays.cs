public class Solution {
    public int FindTheDistanceValue(int[] arr1, int[] arr2, int d) => arr1.Count(m => !arr2.Any(n => Math.Abs(m - n) <= d));
}
