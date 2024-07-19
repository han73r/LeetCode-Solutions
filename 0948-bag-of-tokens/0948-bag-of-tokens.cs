using System;

public class Solution {
    public int BagOfTokensScore(int[] tokens, int power) {
        if (tokens.Length == 0 || tokens.Length <= 1 && power < tokens[0]) {
            return 0;
        }

        int score = 0;
        int length = tokens.Length - 1;
        Array.Sort(tokens);

        if (tokens[0] < power) {
            power -= tokens[0];
            score++;
        } else {
            return 0;
        }

        for (int i = 1; i <= length; i++) {
            if (power >= tokens[i]) {
                power -= tokens[i];
                score++;
            } else if (score > 0 && i + 1 < length) {
                power += tokens[length];
                length--;
                score--;
                i--;
            }
        }
        return score;
    }
}