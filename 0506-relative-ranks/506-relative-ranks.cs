using System.Collections.Generic;
using System.Linq;

public class Solution {
    private const string gold = "Gold Medal";
    private const string silver = "Silver Medal";
    private const string bronze = "Bronze Medal";

    public string[] FindRelativeRanks(int[] score) {
        var scoreDict = PlaceAthletesOnTheirScores(score);
        return ConvertScoresToPlaces(score, scoreDict);
    }

    private Dictionary<int, string> PlaceAthletesOnTheirScores(int[] score) {
        Dictionary<int, string> scores = new();
        score = score.OrderByDescending(x => x).ToArray();
        for (int i = 0; i < score.Length; i++) {
            if (i < 3) {
                switch (i) {
                    case 0: scores.Add(score[i], gold); break;
                    case 1: scores.Add(score[i], silver); break;
                    case 2: scores.Add(score[i], bronze); break;
                }
            } else {
                scores.Add(score[i], (i + 1).ToString());
            }

        }
        return scores;
    }

    private string[] ConvertScoresToPlaces(int[] score, Dictionary<int, string> scoreDict) {
        string[] result = new string[score.Length];
        for (int i = 0; i < score.Length; i++) {
            result[i] = scoreDict[score[i]];
        }
        return result;
    }
}