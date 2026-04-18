public class Solution {
    public int MirrorDistance(int n) {
        var sb = new StringBuilder(n.ToString());
        for (int i = 0, j = sb.Length - 1; i < j; i++, j--){
            (sb[i], sb[j]) = (sb[j], sb[i]);
        }
        int reversed = int.Parse(sb.ToString());
        return Math.Abs(n - reversed);
    }
}
