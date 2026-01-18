public class Solution {
    public int LargestMagicSquare(int[][] grid) {
        int m=grid.Length;
        int n=grid[0].Length;      
        int[,] rowPrefix=new int[m,n+1];
        int[,] colPrefix=new int[m+1,n];

        for(int i=0;i<m;i++){
            for(int j=0;j<n;j++){
                rowPrefix[i,j+1]=rowPrefix[i,j]+grid[i][j];
                colPrefix[i+1,j]=colPrefix[i,j]+grid[i][j];
            }
        }

        int maxK=Math.Min(m,n);
        for(int k=maxK;k>=2;k--){
            for(int i=0;i<=m-k;i++){
                for(int j=0;j<=n-k;j++)
                    if(IsMagicSquare(grid,rowPrefix,colPrefix,i,j,k)) return k;
            }
        }
        return 1;
    }

    private bool IsMagicSquare(int[][] grid,int[,] rowP, int[,] colP, int r, int c, int k){
        int target=rowP[r,c+k]-rowP[r,c];
        for(int i=0;i<k;i++){
            int currentSum=rowP[r+i,c+k]-rowP[r+i,c];
            if(currentSum!=target) return false;
        }
        for(int j=0;j<k;j++){
            int currentSum=colP[r+k,c+j]-colP[r,c+j];
            if(currentSum!=target) return false;
        }
        int diag1=0;
        for(int i=0;i<k;i++)
            diag1+=grid[i+r][i+c];
        if(diag1!=target) return false;
        int diag2=0;
        for(int i=0;i<k;i++)
            diag2+=grid[r+i][c+(k-1)-i];
        if(diag2!=target) return false;
        return true;
    }
}
