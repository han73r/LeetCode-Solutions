public class Solution {
    public int NumJewelsInStones(string jewels, string stones) {
        var jewelsSet = new HashSet<char>(jewels);
        int count = 0;
        foreach (char ch in stones)
            if (jewelsSet.Contains(ch)) count++;
        return count;
    }
}
