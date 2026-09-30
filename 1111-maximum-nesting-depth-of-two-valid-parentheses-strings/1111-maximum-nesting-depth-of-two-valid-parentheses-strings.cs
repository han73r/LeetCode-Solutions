public class Solution {
    public int[] MaxDepthAfterSplit(string seq) {
        int[] result = new int[seq.Length];
      
        for (int i = 0; i < seq.Length; ++i) {
            bool isOpen = seq[i] == '(';
            bool isEven = (i % 2) == 0;
            result[i] = (isOpen == isEven) ? 0 : 1;
        }

        return result;
    }
}
