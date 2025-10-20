public class Solution {
    public int FinalValueAfterOperations(string[] operations) {
        int x = 0;
        foreach (string op in operations)
            x += 44 - op[1];
        return x;
    }
}
