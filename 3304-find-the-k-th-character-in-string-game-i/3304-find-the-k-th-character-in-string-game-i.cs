using System.Text;
using System;

public class Solution{
    private static StringBuilder word = new StringBuilder("a");
    public char KthCharacter(int k) {
        if (word.Length > k) return (char)word[k - 1];
        while (word.Length < k)
            GenerateString();
        return (char)word[k - 1];
    }
    private void GenerateString() {
        int n = word.Length;
        for (int i = 0; i < n; i++)
            word.Append((char)(word[i] + 1));
        Console.WriteLine(word);
    }
}