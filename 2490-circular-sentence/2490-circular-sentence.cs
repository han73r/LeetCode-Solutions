public class Solution {
    public bool IsCircularSentence(string sentence) {
        var l = sentence.Length - 1;
        if (l == 0) return true;
        if (sentence[0] != sentence[l]) return false;
        for (int i = 1; i < l; i++) {
            if (sentence[i] == ' ') {
                if (sentence[i - 1] != sentence[i + 1]) {
                    return false;
                }
            }
        }
        return true;
    }
}