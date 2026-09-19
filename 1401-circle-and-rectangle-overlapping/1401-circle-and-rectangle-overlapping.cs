public class Solution {
    public bool CheckOverlap(int radius, int x_center, int y_center, int x1, int y1, int x2, int y2) {
        var x_square = ClosestToCenter(x_center, x1, x2);
        var y_square = ClosestToCenter(y_center, y1, y2);
        return DistanceSquared(x_center - x_square, y_center - y_square) <= radius * radius;
    }
    
    private static int ClosestToCenter(int a_center, int a1, int a2) {
        return a_center < a1 ? a1 : a_center > a2 ? a2 : a_center;
    }
    
    private static int DistanceSquared(int x, int y) {
        return x*x + y*y;
    }
}
