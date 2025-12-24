public class Solution {
    public int MinimumBoxes(int[] apple, int[] capacity) {
        var sum = 0;
        foreach (int i in apple) {
            sum += i;
        }
        var counter = 0;
        while (sum > 0) {
            var max = capacity.Max();
            var index = Array.IndexOf(capacity, max);
            sum -= max;
            capacity[index] = -1;
            counter++;
        }
        return counter;
    }
}
