using System.Collections.Generic;
using System;

public class Solution {
    public int MaxScoreWords(string[] words, char[] letters, int[] score) {
        var letterDictAmountsAndScores = FillScoreDictionary(letters, score);
        return MaxScoreWordsBacktrack(words, 0, letterDictAmountsAndScores);
    }
    private int MaxScoreWordsBacktrack(string[] words, int index, Dictionary<int, int[]> letterDict) {
        if (index == words.Length) {
            return 0;
        }
        // Skip the current word
        int maxScore = MaxScoreWordsBacktrack(words, index + 1, letterDict);
        // Create a copy of the letter dictionary for the recursive call
        var letterDictCopy = new Dictionary<int, int[]>(letterDict.Count);
        foreach (var kvp in letterDict) {
            letterDictCopy[kvp.Key] = new int[] { kvp.Value[0], kvp.Value[1] };
        }
        // Try to use the current word
        int currentWordScore = TryToCreateThisWord(words[index], letterDictCopy);
        if (currentWordScore > 0) {
            maxScore = Math.Max(maxScore, currentWordScore + MaxScoreWordsBacktrack(words, index + 1, letterDictCopy));
        }
        return maxScore;
    }
    private Dictionary<int, int[]> FillScoreDictionary(char[] letters, int[] score) {
        Dictionary<int, int[]> lettersDict = new();
        foreach (char letter in letters) {
            int letterIndex = letter - 'a';
            if (!lettersDict.ContainsKey(letterIndex)) {
                lettersDict[letterIndex] = new int[2] { 0, score[letterIndex] };
            }
            lettersDict[letterIndex][0]++;
        }
        return lettersDict;
    }
    private int TryToCreateThisWord(string word, Dictionary<int, int[]> dict) {
        int score = 0;
        var usedLetters = new List<int>();
        foreach (char ch in word) {
            int index = ch - 'a';
            if (dict.ContainsKey(index) && dict[index][0] > 0) {
                score += dict[index][1];
                dict[index][0]--;
                usedLetters.Add(index);
            } else {
                // Restore counts if word cannot be created
                foreach (int usedIndex in usedLetters) {
                    dict[usedIndex][0]++;
                }
                return 0;
            }
        }
        return score;
    }
}