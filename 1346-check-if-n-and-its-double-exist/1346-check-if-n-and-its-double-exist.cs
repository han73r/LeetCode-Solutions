public class Solution {
    public bool CheckIfExist(int[] arr) {
        int i, j;
        var l = arr.Length;
        for (i = 0; i < l; i++) {
            for (j = i + 1; j < arr.Length; j++) {
                if (arr[i] == 2 * arr[j] ||
                    (arr[j] % 2 == 0 && arr[i] == arr[j] / 2))
                    return true;
            }
        }
        return false;
    }
}