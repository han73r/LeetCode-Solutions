public class Solution {
    public int MaxStability(int n, int[][] edges, int k) {
        int[] parent = new int[n];
        for (int i = 0; i < n; i++) parent[i] = i;

        int Find(int i) {
            while (i != parent[i]) {
                parent[i] = parent[parent[i]];
                i = parent[i];
            }
            return i;
        }

        int minM = int.MaxValue;
        int compCount = n;
        
        ulong[] opt = new ulong[edges.Length];
        int oIdx = 0;
        // STEP 1: Process Mandatory Edges (must == 1)
        foreach (var e in edges) {
            if (e[3] == 1) {
                int ru = Find(e[0]);
                int rv = Find(e[1]);
                // If a cycle is formed by mandatory edges, valid spanning tree is impossible
                if (ru == rv) return -1;
                parent[ru] = rv;
                compCount--;
                // Track the minimum mandatory edge, as it forms a hard ceiling on our answer
                if (e[2] < minM) minM = e[2];
            }
        }

        // STEP 2: Filter and Pack Optional Edges (must == 0)
        foreach (var e in edges) {
            if (e[3] == 0) {
                int ru = Find(e[0]);
                int rv = Find(e[1]);
                if (ru != rv) {
                    // Pack into 64 bits: [Weight: 30 bits] | [ru: 17 bits] | [rv: 17 bits]
                    opt[oIdx++] = ((ulong)e[2] << 34) | ((ulong)ru << 17) | (uint)rv;
                }
            }
        }
        // If already fully connected by mandatory edges, we are done
        if (compCount == 1) return minM;
        // STEP 3: Radix Sort Optional Edges by Weight (Ascending)
        if (oIdx > 1) {
            ulong[] temp = new ulong[oIdx];
            int[] count = new int[256];
            // Start shifting at 34 to ONLY sort by the weight bits, ignoring node IDs
            for (int shift = 34; shift < 64; shift += 8) {
                System.Array.Clear(count, 0, 256);
                for (int i = 0; i < oIdx; i++) count[(opt[i] >> shift) & 0xFF]++;
                for (int i = 1; i < 256; i++) count[i] += count[i - 1];
                for (int i = oIdx - 1; i >= 0; i--) temp[--count[(opt[i] >> shift) & 0xFF]] = opt[i];
                // Swap arrays for the next pass
                ulong[] swap = opt; 
                opt = temp; 
                temp = swap;
            }
        }
        // Array to store the weights of optional edges we actually use
        int[] upg = new int[compCount - 1];
        int upgCount = 0;

        // STEP 4: Build Maximum Spanning Tree (Greedy from largest weight)
        for (int i = oIdx - 1; i >= 0; i--) {
            ulong packed = opt[i];

            // Unpack using bitwise masks (0x1FFFF gets the lowest 17 bits)
            int ru = Find((int)((packed >> 17) & 0x1FFFF));
            int rv = Find((int)(packed & 0x1FFFF));
            
            if (ru != rv) {
                parent[ru] = rv;
                // Extract weight (top 30 bits) and store it
                upg[upgCount++] = (int)(packed >> 34);
                if (--compCount == 1) break;
            }
        }

        // If we exhausted edges but graph isn't connected
        if (compCount > 1) return -1;

        // STEP 5: Apply 'k' upgrades to the smallest used optional edges
        // Note: 'upg' naturally stores edges from largest to smallest, so we traverse backwards
        for (int i = upgCount - 1; i >= 0; i--) {
            if (k > 0) {
                k--;
                int upgraded = upg[i] << 1; // Multiply by 2
                if (upgraded < minM) minM = upgraded;
            } else {
                if (upg[i] < minM) minM = upg[i];
                break; // Remaining edges are larger, no need to check further
            }
        }

        return minM;
    }
}
