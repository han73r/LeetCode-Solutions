public class Solution {
    public int MaxChunksToSorted(int[] arr) {
        var length = arr.Length;
        int[] split = (int[])arr.Clone();
        Array.Sort(split);
        int c = 0, ind = -1;
        for (int i = 0; i < length; i++) {
            ind = Math.Max(ind, Array.IndexOf(split, arr[i]));
            if (ind == i)
                c++;
        }
        return c;
    }
}