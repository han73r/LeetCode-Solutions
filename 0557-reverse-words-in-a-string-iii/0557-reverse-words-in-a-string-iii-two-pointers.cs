public class Solution {
    public string ReverseWords(string s) {
        char[] charArr = s.ToCharArray();
        int length = charArr.Length;
        int left = 0;
        for (int right = 0; right <= length; right++) {
            if (right == length || charArr[right] == ' ') {
                ReverseWord(charArr, left, right - 1);
                left = right + 1;
            }
        }
        return new string(charArr);
    }
    private static void ReverseWord(char[] arr, int left, int right) {
        while (left < right) {
            char temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;
            left++;
            right--;
        }
    }
}