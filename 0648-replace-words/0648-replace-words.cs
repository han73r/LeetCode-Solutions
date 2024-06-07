using System.Collections.Generic;
using System.Text;

public class Solution {
    public class TrieNode {
        public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
        public string Word = null;
    }
    public class Trie {
        private TrieNode Root;
        public Trie() {
            Root = new TrieNode();
        }
        public void Insert(string word) {
            TrieNode node = Root;
            foreach (char c in word) {
                if (!node.Children.ContainsKey(c)) {
                    node.Children[c] = new TrieNode();
                }
                node = node.Children[c];
            }
            node.Word = word;
        }
        public string SearchRoot(string word) {
            TrieNode node = Root;
            foreach (char c in word) {
                if (!node.Children.ContainsKey(c)) {
                    break;
                }
                node = node.Children[c];
                if (node.Word != null) {
                    return node.Word;
                }
            }
            return word;
        }
    }
    public string ReplaceWords(IList<string> dictionary, string sentence) {
        Trie trie = new Trie();
        foreach (string root in dictionary) {
            trie.Insert(root);
        }
        StringBuilder result = new StringBuilder();
        string[] words = sentence.Split(' ');
        for (int i = 0; i < words.Length; i++) {
            if (i > 0) {
                result.Append(' ');
            }
            result.Append(trie.SearchRoot(words[i]));
        }
        return result.ToString();
    }
}