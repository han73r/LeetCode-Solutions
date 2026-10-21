public class Solution {
    private const int Impossible = -1;
    private const int UnsortableLength = 2;

    public int MinOperations(string s) {
        int length = s.Length;
        char minChar = char.MaxValue;
        char maxChar = char.MinValue;
        bool isSorted = true;

        for (int i = 0; i < length; i++) {
            if (s[i] < minChar) {
                minChar = s[i];
            }

            if (s[i] > maxChar) {
                maxChar = s[i];
            }

            if (i > 0 && s[i - 1] > s[i]) {
                isSorted = false;
            }
        }

        if (isSorted) {
            return 0;
        }

        if (length == UnsortableLength) {
            return Impossible;
        }

        if (s[0] == minChar || s[length - 1] == maxChar) {
            return 1;
        }

        for (int i = 1; i < length - 1; i++) {
            if (s[i] == minChar || s[i] == maxChar) {
                return 2;
            }
        }

        return 3;
    }
}
