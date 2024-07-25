public class Solution {
    public int[] SortArray(int[] nums) {
        if (nums == null || nums.Length <= 1) return nums;
        MergeSort(nums, 0, nums.Length - 1);
        return nums;
    }
    private void MergeSort(int[] nums, int left, int right) {
        if (left < right) {
            int mid = left + (right - left) / 2;
            MergeSort(nums, left, mid);
            MergeSort(nums, mid + 1, right);
            Merge(nums, left, mid, right);
        }
    }
    private void Merge(int[] nums, int left, int mid, int right) {
        int n1 = mid - left + 1;
        int n2 = right - mid;
        int[] leftArray = new int[n1];
        int[] rightArray = new int[n2];
        for (int i = 0; i < n1; i++)
            leftArray[i] = nums[left + i];
        for (int j = 0; j < n2; j++)
            rightArray[j] = nums[mid + 1 + j];
        int iIndex = 0, jIndex = 0, k = left;
        while (iIndex < n1 && jIndex < n2) {
            if (leftArray[iIndex] <= rightArray[jIndex]) {
                nums[k] = leftArray[iIndex];
                iIndex++;
            } else {
                nums[k] = rightArray[jIndex];
                jIndex++;
            }
            k++;
        }
        while (iIndex < n1) {
            nums[k] = leftArray[iIndex];
            iIndex++;
            k++;
        }
        while (jIndex < n2) {
            nums[k] = rightArray[jIndex];
            jIndex++;
            k++;
        }
    }
}