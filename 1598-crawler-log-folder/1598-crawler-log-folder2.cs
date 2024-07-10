public class Solution {
    private readonly char qualifier = '.';
    public int MinOperations(string[] logs) {
        int operations = default;
        foreach (var log in logs) {
            if (log[1] == qualifier) {
                if (operations != 0) {
                    operations--;
                }
            } else if (log[0] != qualifier) {
                operations++;
            }
        }
        return operations;
    }
}