using System.Linq;

public class Solution 
{
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        int i = m - 1;                  // start from last index for num1
        int j = n - 1;                  // start from index for num2
        int k = m + n - 1;              // start from last index for new num1

        // Start from end
        while (i >= 0 && j >= 0)
        {
            if (nums1[i] > nums2[j])
            {
                nums1[k] = nums1[i];
                i--;
            }
            else
            {
                nums1[k] = nums2[j];
                j--;
            }
            k--;
        }
        while (j >= 0)
        {
            nums1[k] = nums2[j];
            j--;
            k--;
        }
    }
}