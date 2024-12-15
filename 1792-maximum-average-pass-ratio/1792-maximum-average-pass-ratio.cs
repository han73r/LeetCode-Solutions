public class Solution {
    public double MaxAverageRatio(int[][] classes, int extraStudents) {
        var maxHeap = new PriorityQueue<(double delta, int pass, int total), double>();
        double totalAverage = 0;
        foreach (var c in classes) {
            int pass = c[0], total = c[1];
            double delta = CalculateDelta(pass, total);
            maxHeap.Enqueue((delta, pass, total), -delta);
        }
        while (extraStudents > 0) {
            var (delta, pass, total) = maxHeap.Dequeue();
            pass++;
            total++;
            extraStudents--;
            delta = CalculateDelta(pass, total);
            maxHeap.Enqueue((delta, pass, total), -delta);
        }
        while (maxHeap.Count > 0) {
            var (_, pass, total) = maxHeap.Dequeue();
            totalAverage += (double)pass / total;
        }
        return totalAverage / classes.Length;
    }
    private double CalculateDelta(int pass, int total) {
        double current = (double)pass / total;
        double next = (double)(pass + 1) / (total + 1);
        return next - current;
    }
}