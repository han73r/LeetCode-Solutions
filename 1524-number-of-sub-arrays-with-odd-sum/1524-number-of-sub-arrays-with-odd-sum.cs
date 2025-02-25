public class Solution {
    public int NumOfSubarrays(int[] arr) {
        const int MOD = 1000000007;
        long oddCount = 0; // Count of odd prefix sums
        long evenCount = 1; // Count of even prefix sums (initially 1 for the empty prefix)
        long currentSum = 0; // Current prefix sum
        long oddSubarrayCount = 0; // Total count of subarrays with odd sums

        foreach (int num in arr) {
            currentSum += num;

            // Check if the current prefix sum is odd or even
            if (currentSum % 2 == 0) {
                // Current sum is even
                oddSubarrayCount = (oddSubarrayCount + oddCount) % MOD;
                evenCount++; // Increment the count of even prefix sums
            } else {
                // Current sum is odd
                oddSubarrayCount = (oddSubarrayCount + evenCount) % MOD;
                oddCount++; // Increment the count of odd prefix sums
            }
        }

        return (int)oddSubarrayCount; // Return the result as an integer
    }

}