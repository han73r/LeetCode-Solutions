public class Solution {
    public char[][] RotateTheBox(char[][] box) {
        int m = box.Length, n = box[0].Length;
        var rotatedBox = new char[n][];
        for (int i = 0; i < n; i++) {
            rotatedBox[i] = new char[m];
            for (int j = 0; j < m; j++) {
                rotatedBox[i][j] = '.';
            }
        }
        for (int i = 0; i < m; i++) {
            int emptySlot = n - 1;
            for (int j = n - 1; j >= 0; j--) {
                if (box[i][j] == '*') {
                    rotatedBox[j][m - 1 - i] = '*';
                    emptySlot = j - 1;
                } else if (box[i][j] == '#') {
                    rotatedBox[emptySlot][m - 1 - i] = '#';
                    emptySlot--;
                } else {
                    rotatedBox[j][m - 1 - i] = '.';
                }
            }
            for (int j = emptySlot; j >= 0; j--) {
                rotatedBox[j][m - 1 - i] = '.';
            }
        }
        return rotatedBox;
    }
}