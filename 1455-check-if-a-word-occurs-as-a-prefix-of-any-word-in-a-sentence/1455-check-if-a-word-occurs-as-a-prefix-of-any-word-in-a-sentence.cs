public class Solution {
    public int IsPrefixOfWord(string sentence, string searchWord) {
        string[] words = sentence.Split(' ');
        var l = words.Length;
        for (int i = 0; i < l; i++) {
            if (words[i].StartsWith(searchWord))
                return i + 1;
        }
        return -1;
    }
}