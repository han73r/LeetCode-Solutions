public class Solution {
    public int MinSumOfLengths(int[] arr, int target) {
        int n = arr.Length;
        int[] minLength = new int[n];

        int left = 0;
        int currentSum = 0;
        int bestLength = int.MaxValue;
        int answer = int.MaxValue;

        for (int right = 0; right < n; right++) {
            currentSum += arr[right];

            while (currentSum > target) {
                currentSum -= arr[left++];
            }

            if (currentSum == target) {
                int currentLength = right - left + 1;

                if (left > 0 && minLength[left - 1] != int.MaxValue) {
                    answer = Math.Min(
                        answer,
                        currentLength + minLength[left - 1]
                    );
                }

                bestLength = Math.Min(bestLength, currentLength);
            }

            minLength[right] = bestLength;
        }

        return answer == int.MaxValue ? -1 : answer;
    }
}
