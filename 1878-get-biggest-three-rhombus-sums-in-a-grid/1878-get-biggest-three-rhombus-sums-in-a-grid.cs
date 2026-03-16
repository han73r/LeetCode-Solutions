public class Solution {
    public int[] GetBiggestThree(int[][] grid) {
        
        int maxSize = Math.Max(grid.Length, grid[0].Length) / 2;

        var result = new SortedSet<int>();

        for(int size = 0; size <= maxSize; size++) {
            for(int i = size; i < grid.Length - size; i++) {
                for(int j = size; j < grid[0].Length - size; j++) {
                    result.Add(GetRombusSum(grid, i, j, size));
                }
            }
        }

        var resultCount = Math.Min(result.Count(), 3);
        var resultArr = new int[resultCount];

        for(int k = 0; k < resultCount; k++) {
            resultArr[k] = result.Max;
            result.Remove(result.Max);
        }

        return resultArr;
    }

    public int GetRombusSum(int[][] grid, int i, int j, int size) {

        if(size == 0) {
            return grid[i][j];
        }

        if(i - size < 0 || i + size >= grid.Length) {
            return -1;
        }

        if(j - size < 0 || j + size >= grid[0].Length) {
            return -1;
        }

        var sum = 0;

        for(int k = 0; k < size; k++) {
            sum += grid[i - size + k][j + k];
        }

        for(int k = 0; k < size; k++) {
            sum += grid[i - k][j - size + k];
        }

        for(int k = 0; k < size; k++) {
            sum += grid[i + size - k][j - k];
        }

        for(int k = 0; k < size; k++) {
            sum += grid[i + k][j + size - k];
        }

        return sum;
    }
}
