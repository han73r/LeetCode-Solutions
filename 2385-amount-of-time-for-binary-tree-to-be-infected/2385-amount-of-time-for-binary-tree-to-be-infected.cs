using System;

public class Solution
{
    public int MinSteps(string s, string t)
    {
        int[] frequencyS = new int[26]; // assuming only lowercase English letters
        int[] frequencyT = new int[26];

        // Count frequencies in string s
        foreach (char c in s)
        {
            frequencyS[c - 'a']++;
        }

        // Count frequencies in string t
        foreach (char c in t)
        {
            frequencyT[c - 'a']++;
        }

        // Calculate the absolute difference in frequencies
        int steps = 0;
        for (int i = 0; i < 26; i++)
        {
            steps += Math.Abs(frequencyS[i] - frequencyT[i]);
        }

        // The final result is half of the total steps since each step affects two characters
        return steps / 2;
    }
}