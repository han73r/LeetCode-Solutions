public class Solution {
    public int MaximizeSquareArea(int totalHeight, int totalWidth, int[] horizontalCuts, int[] verticalCuts) {
        long MOD = 1000000007;

        List<int> prep(int[] cuts, int limit) {
            Array.Sort(cuts);
            var arr = new List<int>(){1};
            arr.AddRange(cuts);
            arr.Add(limit);
            return arr;
        }

        var h = prep(horizontalCuts, totalHeight);
        var v = prep(verticalCuts, totalWidth);

        var set = new HashSet<int>();
        for(int i=0;i<h.Count;i++)
            for(int j=i+1;j<h.Count;j++)
                set.Add(h[j]-h[i]);

        long best = 0;
        for(int i=0;i<v.Count;i++)
            for(int j=i+1;j<v.Count;j++) {
                int d = v[j]-v[i];
                if(d>best && set.Contains(d)) best=d;
            }

        return best==0 ? -1 : (int)((best*best)%MOD);
    }
}
