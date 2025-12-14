public class Solution {
    public int NumJewelsInStones(string jewels, string stones) {
        var jewelsDic = new Dictionary<char, int>();
        var counter = 0;
        foreach (char ch in jewels) {
            jewelsDic.Add(ch,0);
        }
        foreach (char ch in stones) {
            if (jewelsDic.ContainsKey(ch))
                counter++;
        }
        return counter;
    }
}
