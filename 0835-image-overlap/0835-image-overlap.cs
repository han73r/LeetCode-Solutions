public class Solution {
    public int LargestOverlap(int[][] img1, int[][] img2) {
        int n = img1.Length;
        List<int[]> imgA = new List<int[]>();
        List<int[]> imgB = new List<int[]>();

        for(int i = 0; i < n; i++){
            for(int j = 0; j < n; j++){
                if(img1[i][j] == 1)
                    imgA.Add(new int[]{i, j});
                if(img2[i][j] == 1)
                    imgB.Add(new int[]{i, j});
            }
        }

        int[,] count = new int[n * 2, n * 2];
        int res = 0;

        foreach(int[] a in imgA){
            foreach(int[] b in imgB){
                int dx = b[0] - a[0] + n;
                int dy = b[1] - a[1] + n;
                count[dx, dy]++;
                res = Math.Max(res, count[dx, dy]);
            }
        }
        
        return res;
    }
}
