using System.Collections.Generic;

public class Solution {
    public bool IsNStraightHand(int[] hand, int groupSize) {
        if (hand.Length == 1)
            return true;
        if (hand.Length % groupSize != 0)
            return false;
        var cardCount = new Dictionary<int, int>();
        foreach (var card in hand) {
            if (cardCount.ContainsKey(card)) {
                cardCount[card]++;
            } else {
                cardCount[card] = 1;
            }
        }
        var minHeap = new SortedSet<int>(cardCount.Keys);
        while (minHeap.Count > 0) {
            int first = minHeap.Min;
            for (int i = 0; i < groupSize; i++) {
                int card = first + i;
                if (!cardCount.ContainsKey(card)) {
                    return false;
                }
                cardCount[card]--;
                if (cardCount[card] == 0) {
                    minHeap.Remove(card);
                    cardCount.Remove(card);
                }
            }
        }
        return true;
    }
}