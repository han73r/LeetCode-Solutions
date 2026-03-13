public class Solution {
    public long MinNumberOfSeconds(int mountainHeight, int[] workerTimes) {
        // Find the fastest (minW) and slowest (maxW) worker times
        int minW = workerTimes[0];
        int maxW = minW;
        int minIdx = 0;
        
        for (int i = 1; i < workerTimes.Length; i++) {
            int w = workerTimes[i];
            if (w < minW) {
                minW = w;
                minIdx = i; // Keep track of the fastest worker's index
            } else if (w > maxW) {
                maxW = w;
            }
        }
        
        // Move the fastest worker to the front of the array.
        if (minIdx != 0) {
            workerTimes[minIdx] = workerTimes[0];
            workerTimes[0] = minW;
        }
        
        // Calculate the average height each worker needs to reduce
        long ceilH = (mountainHeight + 0L + workerTimes.Length - 1) / workerTimes.Length;
        // Calculate the total time units needed for that average height
        long tasks = ceilH * (ceilH + 1) / 2L;
        
        // l is the theoretical minimum time (if everyone is as fast as the fastest worker)
        long l = tasks * minW;
        // r is the theoretical maximum time (if everyone is as slow as the slowest worker)
        long r = tasks * maxW;
        long ans = r;
        
        // Binary search for the minimum time
        while (l <= r) {
            long mid = l + ((r - l) >> 1); // mid is the guessed time in seconds
            long mid2 = mid << 1;          // 2 * mid, used for solving the quadratic equation
            long sum = 0;                  // Total height reduced by all workers in 'mid' seconds
            
            for (int i = 0; i < workerTimes.Length; i++) {
                // val represents (2 * mid) / workerTime
                // We need to find x such that x * (x + 1) <= val
                long val = mid2 / workerTimes[i]; 
                if (val >= 2) {
                    // Approximate x using square root
                    long x = (long)System.Math.Sqrt(val);
                    // Adjust down if the approximation is slightly too large
                    if (x * (x + 1) > val) x--;
                    
                    // Add this worker's contribution to the total height reduced
                    // If we already reached the mountainHeight, break early to save time
                    if ((sum += x) >= mountainHeight) break;
                }
            }
            
            // If the workers can reduce the mountain height within 'mid' seconds
            if (sum >= mountainHeight) {
                ans = mid;     // Record this as a valid answer
                r = mid - 1;   // Try to find a smaller time
            } else {
                l = mid + 1;   // Time is too short, increase the guessed time
            }
        }
        
        return ans;
    }
}
