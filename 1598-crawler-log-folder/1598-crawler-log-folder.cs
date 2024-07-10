public class Solution {
    private readonly string doNothing = "./";
    private readonly string moveToTheparent = "../";
    public int MinOperations(string[] logs) {
        int operations = default;
        foreach (var log in logs) {
            if (log == moveToTheparent) {
                if (operations > 0) {
                    operations--;
                }
            } else if (log != doNothing) {
                operations++;
            }
        }
        return operations;
    }
}