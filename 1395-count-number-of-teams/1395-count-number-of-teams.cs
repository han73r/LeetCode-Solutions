public class Solution {
    public int NumTeams(int[] rating) {
        int length = rating.Length;
        int[] leftSmaller = new int[length];
        int[] rightSmaller = new int[length];
        int[] leftLarger = new int[length];
        int[] rightLarger = new int[length];
        for (int i = 0; i < length; i++) {
            for (int j = 0; j < i; j++) {
                if (rating[j] < rating[i]) {
                    leftSmaller[i]++;
                }
                if (rating[j] > rating[i]) {
                    leftLarger[i]++;
                }
            }
            for (int j = i + 1; j < length; j++) {
                if (rating[j] > rating[i]) {
                    rightLarger[i]++;
                }
                if (rating[j] < rating[i]) {
                    rightSmaller[i]++;
                }
            }
        }
        return Count(leftSmaller, rightSmaller, leftLarger, rightLarger, length);
    }

    private int Count(int[] leftSmaller, int[] rightSmaller, int[] leftLarger, int[] rightLarger, int length) {
        int result = default;
        for (int i = 0; i < length; i++) {
            result += leftSmaller[i] * rightLarger[i] + leftLarger[i] * rightSmaller[i];
        }
        return result;
    }
}