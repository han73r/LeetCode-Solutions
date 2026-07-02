public class Solution {
    public bool FindSafeWalk(IList<IList<int>> grid, int health) {
        int[] dx4 = {0 , 1 , 0 , -1};
        int[] dy4 = {1 , 0 , -1 , 0};

        Queue<(int, int, int)>q = new Queue<(int, int, int)>();

        int[,] best = new int[grid.Count, grid[0].Count];
        for(int i=0; i<grid.Count; i++){
            for(int j=0; j<grid[0].Count; j++){
                best[i,j] = -1;
            }
        }
        best[0,0] = health;
        if(grid[0][0] == 1)
            best[0,0]--;
        
        q.Enqueue((0, 0, best[0,0]));

        while(q.Count > 0){
            var (x , y , h) = q.Dequeue();
            
            if(x == grid.Count-1 && y == grid[0].Count-1){
                return true;
            }

            for(int i=0; i<4; i++){
                int nx = x + dx4[i];
                int ny = y + dy4[i];

                if(nx > -1 && nx < grid.Count && ny > -1 && ny < grid[0].Count){
                    int nh = h - grid[nx][ny];

                    if(nh > 0 && nh > best[nx, ny]){
                        best[nx, ny] = nh;
                        q.Enqueue((nx, ny, nh));
                    }
                }
            }
        }

        return false;
    }
}
