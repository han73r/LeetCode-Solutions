public class Solution {
    public bool Exist(char[][] board, string word) {
        for (int i = 0; i < board.Length; i++) {
            for (int j = 0; j < board[i].Length; j++) {
                if (board[i][j] == word[0] && DFS(board, i, j, word, 0))
                    return true;
            }
        }
        return false;
    }
    private bool DFS(char[][] board, int i, int j, string word, int index) {
        if (index == word.Length) return true;
        if (i < 0 || j < 0 || i >= board.Length || j >= board[0].Length || board[i][j] != word[index]) return false;
        char temp = board[i][j];
        board[i][j] = ' ';
        bool found = DFS(board, i + 1, j, word, index + 1) ||
                     DFS(board, i - 1, j, word, index + 1) ||
                     DFS(board, i, j + 1, word, index + 1) ||
                     DFS(board, i, j - 1, word, index + 1);
        board[i][j] = temp;
        return found;
    }
}