using System.Collections.Generic;
using System;

public class Solution {
    public int[] DeckRevealedIncreasing(int[] deck) {
        Array.Sort(deck);
        int n = deck.Length;
        int[] result = new int[n];
        Queue<int> indexes = new Queue<int>();
        for (int i = 0; i < n; i++) {
            indexes.Enqueue(i);
        }
        for (int i = 0; i < n; i++) {
            result[indexes.Dequeue()] = deck[i];
            if (indexes.Count > 0) {
                indexes.Enqueue(indexes.Dequeue());
            }
        }
        return result;
    }
}