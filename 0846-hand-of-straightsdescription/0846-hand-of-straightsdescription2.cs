using System.Collections.Generic;
using System;

public class Solution {
    public bool IsNStraightHand(int[] hand, int groupSize) {
        if (hand.Length == 1)
            return true;
        if (hand.Length % groupSize != 0)
            return false;
        Array.Sort(hand);
        Dictionary<int, int> cardCount = new();
        foreach (var card in hand) {
            if (cardCount.ContainsKey(card)) {
                cardCount[card]++;
            } else {
                cardCount[card] = 1;
            }
        }
        foreach (int card in hand) {
            if (cardCount[card] == 0) {
                continue;
            }
            for (int i = 0; i < groupSize; i++) {
                int currentCard = card + i;
                if (!cardCount.ContainsKey(currentCard) || cardCount[currentCard] == 0) {
                    return false;
                }
                cardCount[currentCard]--;
            }
        }
        return true;
    }
}